using Application.Contracts.Persistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
 
    internal class SuccessedContractRepository : BaseAsyncRepository<SuccessedContract>, ISuccessedContractRepository
    {
        public SuccessedContractRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<SuccessedContract> CreateSuccessedContractAsync(SuccessedContract successedContract)
        {
            var newSuccessedContract = successedContract;
            await base.AddAsync(newSuccessedContract);
            return newSuccessedContract;
        }
        public async Task<SuccessedContract> GetSuccessedContractByIdAsync(long id)
        {
            return await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
     
        public async Task<SuccessedContract> UpdateSuccessedContractAsync(SuccessedContract successedContract)
        {
            await base.UpdateAsync(successedContract);
            return successedContract;
        }
        public async Task<SuccessedContract> DeleteSuccessedContractByIdAsync(long id)
        {
            var fetchedSuccessedContract = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));

            await base.DeleteAsync(fetchedSuccessedContract);
            return fetchedSuccessedContract;
        }
        public async Task<List<SuccessedContract>> GetAll()
        {
            return await base.TableNoTracking.ToListAsync();    
        }

       
    }
}
