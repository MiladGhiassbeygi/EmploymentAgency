using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Application.Contracts.WritePersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateWorkExperienceWorker : BackgroundService
    {
        private readonly ChannelQueue<WorkExperienceUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateWorkExperienceWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateWorkExperienceWorker(ChannelQueue<WorkExperienceUpdated> readModelChannel, ILogger<AddUpdateWorkExperienceWorker> logger, IServiceProvider serviceProvider)
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
                            var mongoWorkExperience = new WorkExperience
                            {
                                WorkExperienceId = workExperience.Id,
                                JobTitle = workExperience.JobTitle,
                                HoursOfWork = workExperience.HoursOfWork,
                                StartDate = workExperience.StartDate,
                                EndDate = workExperience.EndDate,
                                SalaryPaid = workExperience.SalaryPaid,
                                TypeOfCooperation = workExperience.TypeOfCooperation,
                                HireCompanies = workExperience.HireCompanies,
                            };

                            await readRepository.UpdateAsync(mongoWorkExperience, x => x.WorkExperienceId == item.WorkExperienceId, stoppingToken);
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