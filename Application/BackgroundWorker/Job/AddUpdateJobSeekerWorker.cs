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
    public class AddUpdateJobSeekerWorker : BackgroundService
    {
        private readonly ChannelQueue<JobSeekerUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateJobSeekerWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateJobSeekerWorker(ChannelQueue<JobSeekerUpdated> readModelChannel, ILogger<AddUpdateJobSeekerWorker> logger, IServiceProvider serviceProvider)
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
                            var mongoJobSeeker = new JobSeeker
                            {
                                JobSeekerId = jobSeeker.Id,
                                FirstName = jobSeeker.FirstName,
                                LastName = jobSeeker.LastName,
                                Email = jobSeeker.Email,
                                LinkedinAddress = jobSeeker.LinkedinAddress,
                                ResumeFilePath = jobSeeker.ResumeFilePath,
                                CountryId = jobSeeker.CountryId,
                                DefinerId = jobSeeker.DefinerId,
                            };

                            await readRepository.UpdateAsync(mongoJobSeeker, x => x.JobSeekerId == item.JobSeekerId, stoppingToken);
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
