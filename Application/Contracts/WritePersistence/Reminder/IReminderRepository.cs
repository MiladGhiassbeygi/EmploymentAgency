using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.WritePersistence.Reminder
{
    public interface IReminderRepository
    {
        Task<ReminderData> CreateReminderAsync(ReminderData reminder);
        Task<ReminderData> GetRemindersByIdAsync(long reminderId);
        Task<ReminderData> UpdateReminderAsync(ReminderData reminder);
        Task<ReminderData> DeleteReminderByIdAsync(long reminderId);
        Task<List<ReminderData>> GetAll();
    }
}
