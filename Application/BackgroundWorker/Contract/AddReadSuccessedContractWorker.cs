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
    public class AddReadSuccessedContractWorker : BackgroundService
    {
        private readonly ChannelQueue<SuccessedContractAdded> _readModelChannel;
        private readonly ILogger<AddReadSuccessedContractWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadSuccessedContractWorker(ChannelQueue<SuccessedContractAdded> readModelChannel, ILogger<AddReadSuccessedContractWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.AddAsync(new SuccessedContract
                            {
                                SuccessedContractId = successedContract.Id,
                                JobSeekerId = successedContract.JobSeekerId,
                                ContractCreatorId = successedContract.ContractCreatorId,
                                Date = successedContract.Date,
                                IsAmountFixed = successedContract.IsAmountFixed,
                                Amount = successedContract.Amount,
                            }, stoppingToken);
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