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
    public class AddReadWorkExperienceWorker : BackgroundService
    {
        private readonly ChannelQueue<WorkExperienceAdded> _readModelChannel;
        private readonly ILogger<AddReadWorkExperienceWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadWorkExperienceWorker(ChannelQueue<WorkExperienceAdded> readModelChannel, ILogger<AddReadWorkExperienceWorker> logger, IServiceProvider serviceProvider)
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
                var workExperienceSkillRepository = scope.ServiceProvider.GetRequiredService<IWorkExperienceSkillRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var workExperience = await writeRepository.GetWorkExperienceByIdAsync(item.WorkExperienceId);
                        
                        
                        var skilllList =  await workExperienceSkillRepository.GetWorkExperienceSkillByIdAsync(item.WorkExperienceId);
                        string skills = "";
                        if (skilllList is not null)
                        {
                            foreach (var essential in skilllList)
                            {
                                skills = skills + essential.Skill.Title + ',';
                            }
                            skills = skills.Remove(skills.Length - 1);

                        }

                        
                        if (workExperience != null)
                        {
                            await readRepository.AddAsync(new WorkExperience
                            {
                              WorkExperienceId = workExperience.Id,
                              JobTitle = workExperience.JobTitle,
                              HoursOfWork = workExperience.HoursOfWork,
                              StartDate = workExperience.StartDate,
                              EndDate  = workExperience.EndDate,
                              SalaryPaid = workExperience.SalaryPaid,
                              TypeOfCooperation = workExperience.TypeOfCooperation,
                              HireCompanies = workExperience.HireCompanies,
                              Skills = skills
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
