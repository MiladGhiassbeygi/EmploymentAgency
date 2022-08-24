using Domain.ReadModel;
using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Contracts.WritePersistence;

namespace Application.BackgroundWorker
{
    public class AddReadEducationalBackgroundWorker : BackgroundService
    {
        private readonly ChannelQueue<EducationalBackgroundAdded> _readModelChannel;
        private readonly ILogger<AddReadEducationalBackgroundWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadEducationalBackgroundWorker(ChannelQueue<EducationalBackgroundAdded> readModelChannel, ILogger<AddReadEducationalBackgroundWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.AddAsync(new EducationalBackground
                            {
                                Degree = educationalbackground.Degree,
                                FieldOfStudy = educationalbackground.FieldOfStudy,
                                JobSeekerId = educationalbackground.JobSeekerId,
                                School = educationalbackground.School,
                                StartDate = educationalbackground.StartDate,
                                EndDate = educationalbackground.EndDate

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
