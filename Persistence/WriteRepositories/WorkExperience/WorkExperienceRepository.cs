using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class WorkExperienceRepository : BaseAsyncRepository<WorkExperience>, IWorkExperienceRepository
    {
        public WorkExperienceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience)
        {
            var newWorkExperience = workExperience;
            await base.AddAsync(newWorkExperience);
            return newWorkExperience;

        }

        public async Task<WorkExperience> DeleteWorkExperienceByIdAsync(int id)
        {
            var fetchedWorkExperience = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedWorkExperience);
            return fetchedWorkExperience;
        }

        public async Task<List<WorkExperience>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new WorkExperience
            { 

            }).ToListAsync();
        }

        public async Task<WorkExperience> GetWorkExperienceByIdAsync(int id)
        {
            var workExperience = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return workExperience;
        }


        public async Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience)
        {
            await base.UpdateAsync(workExperience);
            return workExperience;
        }


    }
}
