using Application.Contracts.WritePersistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class WorkExperienceSkillRepository : BaseAsyncRepository<WorkExperienceSkill>, IWorkExperienceSkillRepository
    {
        public WorkExperienceSkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<WorkExperienceSkill> CreateWorkExperienceSkillAsync(WorkExperienceSkill workExperienceSkill)
        {
            await base.AddAsync(workExperienceSkill);
            return workExperienceSkill;

        }

        public async Task<WorkExperienceSkill> DeleteWorkExperienceSkillByIdAsync(int id)
        {
            var fetchedWorkExperienceSkill = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedWorkExperienceSkill);
            return fetchedWorkExperienceSkill;
        }

        public async Task<List<WorkExperienceSkill>> GetAll()
        {
            return await base.TableNoTracking.ToListAsync();
        }

        public async Task<List<WorkExperienceSkill>> GetWorkExperienceSkillByIdAsync(int id)
        {
            return await base.TableNoTracking.Where(x => x.WorkExperienceId.Equals(id)).ToListAsync();
            
        }


        public async Task<WorkExperienceSkill> UpdateWorkExperienceSkillAsync(WorkExperienceSkill workExperienceSkill)
        {
            await base.UpdateAsync(workExperienceSkill);
            return workExperienceSkill;
        }


    }
}
