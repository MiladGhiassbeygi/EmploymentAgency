using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class EducationalBackgroundRepository : BaseAsyncRepository<EducationalBackground>, IEducationalBackgroundRepository
    {
        public EducationalBackgroundRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<EducationalBackground> CreateEducationalBackgroundAsync(EducationalBackground EducationalBackground)
        {
            var newEducationalBackground = EducationalBackground;
            await base.AddAsync(newEducationalBackground);
            return newEducationalBackground;

        }

        public async Task<EducationalBackground> DeleteEducationalBackgroundByIdAsync(int id)
        {
            var fetchedEducationalBackground = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedEducationalBackground);
            return fetchedEducationalBackground;
        }

        public async Task<List<EducationalBackground>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new EducationalBackground
            { 

            }).ToListAsync();
        }

        public async Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id)
        {
            var EducationalBackground = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return EducationalBackground;
        }

        public async Task<EducationalBackground> UpdateEducationalBackgroundAsync(EducationalBackground EducationalBackground)
        {
            await base.UpdateAsync(EducationalBackground);
            return EducationalBackground;
        }

    }
}
