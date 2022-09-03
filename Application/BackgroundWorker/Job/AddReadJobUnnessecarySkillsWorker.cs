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
    public class AddReadJobUnnessecarySkillsWorker : BackgroundService
    {
        private readonly ChannelQueue<JobUnnessecarySkillsAdded> _readModelChannel;
        private readonly ILogger<AddReadJobUnnessecarySkillsWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadJobUnnessecarySkillsWorker(ChannelQueue<JobUnnessecarySkillsAdded> readModelChannel, ILogger<AddReadJobUnnessecarySkillsWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobUnnessecarySkillsRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobUnnessecarySkillsRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var jobUnnecessarySkills = await writeRepository.GetJobUnnessecarySkillsByIdAsync(item.JobUnnessecarySkillId);

                        if (jobUnnecessarySkills.Count() != 0)
                        { 

                            foreach(var jobUnnessecarySkill in jobUnnecessarySkills)
                            {
                                await readRepository.AddAsync(new JobUnnecessarySkills
                                {
                                    JobId=(long)jobUnnessecarySkill.JobId,
                                    SkillId=(short)jobUnnessecarySkill.SkillId,
                                }, stoppingToken);
                            }
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
