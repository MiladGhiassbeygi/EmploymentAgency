using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadEmployerCommissionRepository : BaseReadRepository<EmployerCommission>, IReadEmployerCommissionRepository
    {
        public ReadEmployerCommissionRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<EmployerCommission> GetEmployerCommissionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.EmployerCommissionId == id, cancellationToken);
        }

        public async Task<List<EmployerCommission>> GetEmployerCommissions()
        {
            return await base.GetAllAsync();
        }

    }
}
