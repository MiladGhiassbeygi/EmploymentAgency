using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateSuccessedContractWorker : BackgroundService
    {
        private readonly ChannelQueue<SuccessedContractUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateSuccessedContractWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateSuccessedContractWorker(ChannelQueue<SuccessedContractUpdated> readModelChannel, ILogger<AddUpdateSuccessedContractWorker> logger, IServiceProvider serviceProvider)
        {
            _readModelChannel = readModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<ISuccessedContractRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadSuccessedContractRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var successedContract = await writeRepository.GetSuccessedContractByIdAsync(item.SuccessedContractId);

                        if (successedContract != null)
                        {
                            var mongoSuccessedContract = new SuccessedContract
                            {
                                SuccessedContractId = successedContract.Id,
                                JobId= successedContract.JobId,
                                JobSeekerId= successedContract.JobSeekerId,
                                Amount= successedContract.Amount,
                                Date= successedContract.Date,
                                IsAmountFixed= successedContract.IsAmountFixed,
                            };

                            await readRepository.UpdateAsync(mongoSuccessedContract, x => x.SuccessedContractId == item.SuccessedContractId, stoppingToken);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }
    }
}
