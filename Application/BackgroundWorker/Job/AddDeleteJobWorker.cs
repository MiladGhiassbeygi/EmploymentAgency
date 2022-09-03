using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteJobWorker : BackgroundService
    {
        private readonly ChannelQueue<JobDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteJobWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteJobWorker(ChannelQueue<JobDeleted> readModelChannel, ILogger<AddDeleteJobWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var job = await writeRepository.GetJobByIdAsync(item.JobId);

                        if (job != null)
                        {
                            await readRepository.DeleteAsync(x => x.JobId == item.JobId, stoppingToken);
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
