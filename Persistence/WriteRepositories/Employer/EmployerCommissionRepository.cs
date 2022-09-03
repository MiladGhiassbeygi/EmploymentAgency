using Application.Contracts.Persistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class EmployerCommissionRepository : BaseAsyncRepository<EmployerCommission>, IEmployerCommissionRepository
    {
        public EmployerCommissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<EmployerCommission> CreateEmployerCommissionAsync(EmployerCommission employerCommission)
        {
            var newEmployerCommission = employerCommission;
            await base.AddAsync(newEmployerCommission);
            return newEmployerCommission;

        }
        public async Task<EmployerCommission> GetEmployerCommissionByIdAsync(long id)
        {
            var employerCommission = await base.TableNoTracking.FirstOrDefaultAsync(x => x.EmployerId.Equals(id));
            return employerCommission;
        }
        public async Task<EmployerCommission> UpdateEmployerCommissionAsync(EmployerCommission employerCommission)
        {
            await base.UpdateAsync(employerCommission);
            return employerCommission;
        }
        public async Task<EmployerCommission> DeleteEmployerCommissionByIdAsync(long id)
        {

            var fetchedEmployerCommission = await base.Table.Where(t => t.EmployerId.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedEmployerCommission);
            return fetchedEmployerCommission;
        }
        public async Task<List<EmployerCommission>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new EmployerCommission
            {
                EmployerId = x.Id,
                IsFixed = x.IsFixed,
                Value = x.Value,

            }).ToListAsync();
        }
    }
}
