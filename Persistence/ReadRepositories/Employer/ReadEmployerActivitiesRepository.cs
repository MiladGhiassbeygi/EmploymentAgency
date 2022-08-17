using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadEmployerActivitiesRepository : BaseReadRepository<EmployerAcivityField>, IReadEmployerActivitiesRepository
    {
        public ReadEmployerActivitiesRepository(IMongoDatabase db) : base(db)
        {

        }

        public Task<EmployerAcivityField> GetEmployerActivityByIdAsync(byte id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.EmployerAcivityFieldId == id, cancellationToken);

        }

        public async Task<List<EmployerAcivityField>> GetEmployerActivities()
        {
            return await base.GetAllAsync();
        }

        public async Task<List<EmployerAcivityField>> FilterByTerm(string term)
        {
            if (term == null)
                return null;
            return await base.GetWithFilterAsync(x => x.Title.Contains(term));
        }
    }
}
