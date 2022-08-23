using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddDeleteJobSeeker
{
    public class AddDeleteEducationalBackgroundWorker : BackgroundService
    {
        private readonly ChannelQueue<EducationalBackgroundDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteEducationalBackgroundWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteEducationalBackgroundWorker(ChannelQueue<EducationalBackgroundDeleted> readModelChannel, ILogger<AddDeleteEducationalBackgroundWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IEducationalBackgroundRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadEducationalBackgroundRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var jobSeeker = await writeRepository.GetEducationalBackgroundByIdAsync(item.EducationalBackgroundId);

                        if (jobSeeker != null)
                        {
                            await readRepository.DeleteAsync(x => x.EducationalBackgroundId == item.EducationalBackgroundId, stoppingToken);
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
