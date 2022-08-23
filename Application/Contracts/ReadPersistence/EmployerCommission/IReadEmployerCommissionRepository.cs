using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadEmployerCommissionRepository : IReadBaseRepository<EmployerCommission>
    {
        Task<List<EmployerCommission>> GetEmployerCommissions();
        Task<EmployerCommission> GetEmployerCommissionByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
