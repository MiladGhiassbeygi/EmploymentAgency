using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundWorker
{
    public class AddReadJobEssentialSkillsWorker : BackgroundService
    {
        private readonly ChannelQueue<JobEssentialSkillAdded> _readModelChannel;
        private readonly ILogger<AddReadJobEssentialSkillsWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadJobEssentialSkillsWorker(ChannelQueue<JobEssentialSkillAdded> readModelChannel, ILogger<AddReadJobEssentialSkillsWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IJobEssentialSkillsRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadJobEssentialSkillsRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var jobEssentialSkills = await writeRepository.GetJobEssentialSkillsByIdAsync(item.JobEssentialSkillId);

                        if (jobEssentialSkills.Count() != 0)
                        {

                            foreach (var jobEssentialSkill in jobEssentialSkills)
                            {
                                await readRepository.AddAsync(new JobEssentialSkills
                                {
                                    JobId = (long)jobEssentialSkill.JobId,
                                    SkillId = (short)jobEssentialSkill.SkillId,
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
