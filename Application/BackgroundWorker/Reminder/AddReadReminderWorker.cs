using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence.Reminder;
using Domain.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Application.BackgroundWorker
{
    public class AddReadReminderWorker : BackgroundService
    {
        private readonly ChannelQueue<ReminderAdded> _readModelChannel;
        private readonly ILogger<AddReadReminderWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddReadReminderWorker(ChannelQueue<ReminderAdded> readModelChannel, ILogger<AddReadReminderWorker> logger, IServiceProvider serviceProvider)
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

                var writeRepository = scope.ServiceProvider.GetRequiredService<IReminderRepository>();
                var readRepository = scope.ServiceProvider.GetRequiredService<IReadReminderRepository>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var reminder = await writeRepository.GetRemindersByIdAsync(item.ReminderId);

                        if (reminder != null)
                        {
                            await readRepository.AddAsync(new ReminderData
                            {
                                ReminderId = reminder.Id,
                                EventDate = reminder.EventDate,
                                Note = reminder.Note,
                                NoteTitle = reminder.NoteTitle,
                                OwnerId = reminder.OwnerId,

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
    