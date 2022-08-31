using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteJobSeekerWorker : BackgroundService
    {
        private readonly ChannelQueue<JobSeekerDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteJobSeekerWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteJobSeekerWorker(ChannelQueue<JobSeekerDeleted> readModelChannel, ILogger<AddDeleteJobSeekerWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobSeekerRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobSeekerRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var jobSeeker = await writeRepository.GetJobSeekerByIdAsync(item.JobSeekerId);

                        if (jobSeeker != null)
                        {
                            await readRepository.DeleteAsync(x => x.JobSeekerId == item.JobSeekerId, stoppingToken);
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
