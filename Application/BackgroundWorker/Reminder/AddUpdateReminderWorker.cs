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
    public class AddUpdateReminderWorker : BackgroundService
    {
        private readonly ChannelQueue<ReminderUpdated> _readModelChannel;
        private readonly ILogger<AddUpdateReminderWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AddUpdateReminderWorker(ChannelQueue<ReminderUpdated> readModelChannel, ILogger<AddUpdateReminderWorker> logger, IServiceProvider serviceProvider)
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
                            var mongoReminder = new ReminderData
                            {
                                ReminderId = reminder.Id,
                                EventDate = reminder.EventDate,
                                NoteTitle = reminder.NoteTitle,
                                Note = reminder.Note
                            };

                            await readRepository.UpdateAsync(mongoReminder, x => x.ReminderId == item.ReminderId, stoppingToken);
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
