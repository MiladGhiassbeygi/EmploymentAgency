using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateJobCommissionWorker : BackgroundService
    {
        private readonly ChannelQueue<JobCommissionUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateJobCommissionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateJobCommissionWorker(ChannelQueue<JobCommissionUpdated> readModelChannel, ILogger<AddUpdateJobCommissionWorker> logger, IServiceProvider serviceProvider)
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
                            var mongoJob = new JobCommission
                            {
                                JobCommissionId = jobCommission.Id,
                                Value = jobCommission.Value,
                                IsFixed = jobCommission.IsFixed
                            };

                            await readRepository.UpdateAsync(mongoJob, x => x.JobCommissionId == item.JobCommissionId, stoppingToken);
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
