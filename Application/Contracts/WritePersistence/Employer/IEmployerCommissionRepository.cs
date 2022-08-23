using Domain.WriteModel;

namespace Application.Contracts.Persistence
{
    public interface IEmployerCommissionRepository
    {
        Task<EmployerCommission> CreateEmployerCommissionAsync(EmployerCommission employerCommission);
        Task<EmployerCommission> GetEmployerCommissionByIdAsync(long id);
        Task<EmployerCommission> UpdateEmployerCommissionAsync(EmployerCommission employerCommission);
        Task<EmployerCommission> DeleteEmployerCommissionByIdAsync(long id);
        Task<List<EmployerCommission>> GetAll();
    }
}
