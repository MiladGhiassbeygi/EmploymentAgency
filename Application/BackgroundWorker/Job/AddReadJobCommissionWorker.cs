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
    public class AddReadJobCommissionWorker : BackgroundService
    {
        private readonly ChannelQueue<JobCommissionAdded> _readModelChannel;
        private readonly ILogger<AddReadJobCommissionWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadJobCommissionWorker(ChannelQueue<JobCommissionAdded> readModelChannel, ILogger<AddReadJobCommissionWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.AddAsync(new JobCommission
                            {
                                JobCommissionId =jobCommission.Id,
                                IsFixed= jobCommission.IsFixed,
                                Value = jobCommission.Value,
                                JobId = jobCommission.JobId,
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
