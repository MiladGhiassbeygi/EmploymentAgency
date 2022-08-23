using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.EmployerCommissionContract
{
    public interface IEmployerCommissionRepository
    {
        Task<EmployerCommission> CreateEmployerCommissionAsync(EmployerCommission employerCommission);
        Task<EmployerCommission> GetEmployerCommissionByIdAsync(int id);
        Task<EmployerCommission> UpdateEmployerCommissionAsync(EmployerCommission employerCommission);
        Task<EmployerCommission> DeleteEmployerCommissionByIdAsync(int id);
        Task<List<EmployerCommission>> GetAll();
    }
}
