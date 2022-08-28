using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadJobCommissionRepository : BaseReadRepository<JobCommission>, IReadJobCommissionRepository
    {
        public ReadJobCommissionRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<JobCommission> GetJobCommissionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.JobCommissionId == id, cancellationToken);
        }

        public async Task<List<JobCommission>> GetJobCommissions()
        {
            return await base.GetAllAsync();
        }

    }
}

