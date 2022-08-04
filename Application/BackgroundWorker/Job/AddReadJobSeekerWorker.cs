using Domain.ReadModel;
using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;

namespace Application.BackgroundWorker.AddReadJobSeeker
{
    public class AddReadJobSeekerWorker : BackgroundService
    {
        private readonly ChannelQueue<JobSeekerAdded> _readModelChannel;
        private readonly ILogger<AddReadJobSeekerWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadJobSeekerWorker(ChannelQueue<JobSeekerAdded> readModelChannel, ILogger<AddReadJobSeekerWorker> logger, IServiceProvider serviceProvider)
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
                            await readRepository.AddAsync(new JobSeeker
                            {
                                JobSeekerId = jobSeeker.Id,
                                FirstName= jobSeeker.FirstName,
                                LastName = jobSeeker.LastName,
                                Email = jobSeeker.Email,
                                CountryId = jobSeeker.CountryId,
                                LinkedinAddress = jobSeeker.LinkedinAddress,
                                ResumeFilePath = jobSeeker.ResumeFilePath
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