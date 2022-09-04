using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Application.Contracts.WritePersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddDeleteWorkExperienceWorker : BackgroundService
    {
        private readonly ChannelQueue<WorkExperienceDeleted> _readModelChannel;
        private readonly ILogger<AddDeleteWorkExperienceWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddDeleteWorkExperienceWorker(ChannelQueue<WorkExperienceDeleted> readModelChannel, ILogger<AddDeleteWorkExperienceWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IWorkExperienceRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadWorkExperienceRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var workExperience = await writeRepository.GetWorkExperienceByIdAsync(item.WorkExperienceId);

                        if (workExperience != null)
                        {
                            await readRepository.DeleteAsync(x => x.WorkExperienceId == item.WorkExperienceId, stoppingToken);
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
