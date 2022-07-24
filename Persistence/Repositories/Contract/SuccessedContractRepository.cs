using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
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
        public async Task<SuccessedContract> GetSuccessedContractByIdAsync(int id)
        {
            return await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<SuccessedContract> GetSuccessedContractByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<SuccessedContract> FindContractByTermAsync(SuccessedContract successedContract)
        {
            throw new NotImplementedException();
        }
        public async Task<SuccessedContract> UpdateSuccessedContractAsync(SuccessedContract successedContract)
        {
            var fetchedSuccessedContract = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(successedContract.Id));

            if (fetchedSuccessedContract == null) return null;

            await base.UpdateAsync(fetchedSuccessedContract);
            return fetchedSuccessedContract;
        }
        public async Task<SuccessedContract> DeleteSuccessedContractByIdAsync(int id)
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
