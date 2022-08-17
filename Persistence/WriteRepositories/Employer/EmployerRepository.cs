using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.ReadRepositories.Common;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class EmployerRepository : BaseAsyncRepository<Employer>,IEmployerRepository
    {
        public EmployerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Employer> CreateEmployerAsync(Employer employer)
        {
            var newEmployer = employer;
            await base.AddAsync(newEmployer);
            return newEmployer;

        }

        public async Task<Employer> DeleteEmployerByIdAsync(long id)
        {
            var fetchedEmployer = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedEmployer);
            return fetchedEmployer;
        }

        public async Task<List<Employer>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new Employer
            { /*Id= x.Id,*/
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                WebsiteLink=x.WebsiteLink,
                NecessaryExplanation=x.NecessaryExplanation,
                FieldOfActivity=x.FieldOfActivity, 
                DefinerId = x.DefinerId
            }).ToListAsync();
        }

        public async Task<Employer> GetEmployerByIdAsync(long id)
        {
            var employer = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return employer;
        }

        public async Task<Employer> GetEmployerByNameAsync(string firstName,string lastName)
        {
            var employer = await base.TableNoTracking.FirstOrDefaultAsync(x => x.FirstName+x.LastName==(firstName+lastName));
            return employer;
        }

        
        public async Task<Employer> UpdateEmployerAsync(Employer employer)
        {
            await base.UpdateAsync(employer);
            return employer;
        }

       
    }
}
