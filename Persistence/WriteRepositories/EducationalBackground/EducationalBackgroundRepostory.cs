using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.WriteRepositories
{
    internal class EducationalBackgroundRepostory : BaseAsyncRepository<EducationalBackground>, IEducationalBackgroundRepository
    {
        public EducationalBackgroundRepostory(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<EducationalBackground> CreateEducationalBackgroundAsync(EducationalBackground educationalBackground)
        {
            var newEducationalBackground = educationalBackground;
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
            var educationalBackground = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return educationalBackground;
        }


        public async Task<EducationalBackground> UpdateEducationalBackgroundAsync(EducationalBackground educationalBackground)
        {
            await base.UpdateAsync(educationalBackground);
            return educationalBackground;
        }


    }
}
