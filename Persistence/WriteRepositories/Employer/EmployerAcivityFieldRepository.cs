using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{ 
    internal class EmployerAcivityFieldRepository : BaseAsyncRepository<EmployerAcivityField>, IEmployerAcivityFieldRepository
    {
        public EmployerAcivityFieldRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<EmployerAcivityField> CreateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField)
        {
            var newEmployerAcivityField = employerAcivityField;
            await base.AddAsync(newEmployerAcivityField);
            return newEmployerAcivityField;

        }
        public async Task<EmployerAcivityField> GetEmployerAcivityFieldByIdAsync(byte id)
        {
            var employerAcivityField = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return employerAcivityField;
        }
        public async Task<EmployerAcivityField> GetEmployerAcivityFieldByTitleAsync(string title)
        {
            var employerAcivityField = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return employerAcivityField;
        }
        public async Task<EmployerAcivityField> UpdateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField)
        {           
            await base.UpdateAsync(employerAcivityField);
            return employerAcivityField;
        }
        public async Task<EmployerAcivityField> DeleteEmployerAcivityFieldByIdAsync(int id)
        {

            var fetchedemployerAcivityField = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedemployerAcivityField);
            return fetchedemployerAcivityField;
        }
        public async Task<List<EmployerAcivityField>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new EmployerAcivityField { Id = x.Id, Title = x.Title }).ToListAsync();
        }
    }
}
