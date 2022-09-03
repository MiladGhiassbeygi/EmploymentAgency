using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteJobCommissionWorker : BackgroundService
    {
        private readonly ChannelQueue<JobCommissionDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteJobCommissionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteJobCommissionWorker(ChannelQueue<JobCommissionDeleted> readModelChannel, ILogger<AddDeleteJobCommissionWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobCommissionRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobCommissionRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var jobCommission = await writeRepository.GetJobCommissionByIdAsync(item.JobCommissionId);

                        if (jobCommission != null)
                        {
                            await readRepository.DeleteAsync(x => x.JobCommissionId == item.JobCommissionId, stoppingToken);
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
