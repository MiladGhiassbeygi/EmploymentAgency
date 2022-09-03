using Application.Contracts.WritePersistence.Reminder;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class ReminderRepository : BaseAsyncRepository<ReminderData>, IReminderRepository
    {
        public ReminderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ReminderData> CreateReminderAsync(ReminderData reminder)
        {
            var newReminder = reminder;
            await base.AddAsync(newReminder);
            return newReminder;
        }

        public async Task<ReminderData> DeleteReminderByIdAsync(long reminderId)
        {
            var fetchedReminder = await base.Table.Where(t => t.Id.Equals(reminderId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedReminder);
            return fetchedReminder;
        }

        public async Task<List<ReminderData>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new ReminderData
            { /*Id= x.Id,*/
                NoteTitle = x.NoteTitle,
                Note = x.Note,
                EventDate = x.EventDate,
                OwnerId = x.OwnerId,
            }).ToListAsync();
        }

        public async Task<ReminderData> GetRemindersByIdAsync(long reminderId)
        {
            var reminder = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(reminderId));
            return reminder;
        }

        public async Task<ReminderData> UpdateReminderAsync(ReminderData reminder)
        {
            var fetchedReminder = await base.Table.Where(t => t.Id.Equals(reminder.Id)).FirstOrDefaultAsync();

            if (fetchedReminder == null) return null;
            await base.UpdateAsync(fetchedReminder);
            return fetchedReminder;
        }

        
    }
}
