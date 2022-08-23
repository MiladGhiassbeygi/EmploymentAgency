using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker.AddUpdateEducationalBackground
{
    public class AddUpdateEducationalBackgroundWorker : BackgroundService
    {
        private readonly ChannelQueue<EducationalBackgroundUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateEducationalBackgroundWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateEducationalBackgroundWorker(ChannelQueue<EducationalBackgroundUpdated> readModelChannel, ILogger<AddUpdateEducationalBackgroundWorker> logger, IServiceProvider serviceProvider)
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
                        var educationalbackground = await writeRepository.GetEducationalBackgroundByIdAsync(item.EducationalBackgroundId);

                        if (educationalbackground != null)
                        {
                            var mongoEducationalBackground = new EducationalBackground
                            {
                                StartDate = educationalbackground.StartDate,
                                EndDate = educationalbackground.EndDate,
                                School = educationalbackground.School,
                                Degree = educationalbackground.Degree,
                                FieldOfStudy = educationalbackground.FieldOfStudy,
                            };

                            await readRepository.UpdateAsync(mongoEducationalBackground, x => x.EducationalBackgroundId == item.EducationalBackgroundId, stoppingToken);
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
