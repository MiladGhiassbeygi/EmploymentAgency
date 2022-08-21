using Domain.ReadModel;
using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Contracts.Persistence.JobContract;
using System.Text;

namespace Application.BackgroundWorker
{
    public class AddReadJobWorker : BackgroundService
    {
        private readonly ChannelQueue<JobAdded> _readModelChannel;
        private readonly ILogger<AddReadJobWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadJobWorker(ChannelQueue<JobAdded> readModelChannel, ILogger<AddReadJobWorker> logger, IServiceProvider serviceProvider)
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
                var jobEssentialSkillsRepository = scope.ServiceProvider.GetRequiredService<IJobEssentialSkillsRepository>();
                var jobUnnessecarySkillRepository = scope.ServiceProvider.GetRequiredService<IJobUnnessecarySkillsRepository>();


                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {

                        var job = await writeRepository.GetJobByIdAsync(item.JobId);
                        
                       
                        var essentialList = await jobEssentialSkillsRepository.GetJobEssentialSkillsByIdAsync(item.JobId);
                        string essentialString = "";
                        if (essentialList is not null)
                        {
                            foreach (var essential in essentialList)
                            {
                                essentialString = essentialString + essential.Skill.Title + ',';
                            }
                            essentialString = essentialString.Remove(essentialString.Length - 1);

                        }
                        
                        var unnessecaryList = await jobUnnessecarySkillRepository.GetJobUnnessecarySkillsByIdAsync(item.JobId);
                        string unnessecaryString = "";
                        if (unnessecaryList is not null)
                        {
                            foreach (var unnessecary in unnessecaryList)
                            {
                                unnessecaryString = unnessecaryString + unnessecary.Skill.Title + ',';
                            }
                            unnessecaryString = unnessecaryString.Remove(unnessecaryString.Length - 1);
                        }
                 

                        if (job != null)
                        {
                            await readRepository.AddAsync(new Job
                            {
                               
                               Title = job.Title,
                               JobId = job.Id,
                               HoursOfWork = job.HoursOfWork,
                               SalaryMin = job.SalaryMin,
                               SalaryMax = job.SalaryMax,
                               AnnualLeave = job.AnnualLeave,
                               ExactAmountRecived = job.ExactAmountRecived,
                               Description = job.Description,
                               Email = job.Email,
                               EssentialSkills = essentialString,
                               UnnecessarySkills = unnessecaryString,
                               HireCompanies = job.HireCompanies,
                               EmployerId = job.EmployerId
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
