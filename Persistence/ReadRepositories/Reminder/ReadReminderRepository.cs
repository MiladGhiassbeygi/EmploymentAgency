using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadReminderRepository : BaseReadRepository<ReminderData>, IReadReminderRepository
    {
        public ReadReminderRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<ReminderData> GetReminderByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.ReminderId == id, cancellationToken);
        }

        public async Task<List<ReminderData>> GetReminders()
        {
            return await base.GetAllAsync();
        }
    }
}
