using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteSuccessedContractWorker : BackgroundService
    {
        private readonly ChannelQueue<SuccessedContractDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteSuccessedContractWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteSuccessedContractWorker(ChannelQueue<SuccessedContractDeleted> readModelChannel, ILogger<AddDeleteSuccessedContractWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.DeleteAsync(x => x.SuccessedContractId == item.SuccessedContractId, stoppingToken);
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
