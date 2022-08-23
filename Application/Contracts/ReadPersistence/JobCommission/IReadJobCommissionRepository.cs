using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadJobCommissionRepository : IReadBaseRepository<JobCommission>
    {
        Task<List<JobCommission>> GetJobCommissions();
        Task<JobCommission> GetJobCommissionByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
