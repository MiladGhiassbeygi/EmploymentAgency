using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundWorker
{
    public class AddUpdateSkillWorker : BackgroundService
    {
        private readonly ChannelQueue<SkillUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateSkillWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateSkillWorker(ChannelQueue<SkillUpdated> readModelChannel, ILogger<AddUpdateSkillWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<ISkillRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadSkillRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var skill = await writeRepository.GetSkillByIdAsync(item.SkillId);

                        if (skill != null)
                        {
                            var mongoEmployer = new Skill
                            {
                                SkillId = item.SkillId,
                                Title = skill.Title,
                            };

                            await readRepository.UpdateAsync(mongoEmployer, x => x.SkillId == item.SkillId, stoppingToken);
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
