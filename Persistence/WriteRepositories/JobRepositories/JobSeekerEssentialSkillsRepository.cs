using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

 namespace Persistence.WriteRepositories
{
    internal class JobSeekerEssentialSkillsRepository : BaseAsyncRepository<JobSeekerEssentialSkills>, IJobSeekerEssentialSkillsRepository
    {
        public JobSeekerEssentialSkillsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        
        public async Task<JobSeekerEssentialSkills> CreateJobSeekerEssentialSkillsAsync(JobSeekerEssentialSkills jobSeekerEssentialSkills)
        {
            var newJobEssentialSkills = jobSeekerEssentialSkills;
            await base.AddAsync(newJobEssentialSkills);
            return newJobEssentialSkills;
        }
        public async Task<JobSeekerEssentialSkills> DeleteJobSeekerEssentialSkillsByIdAsync(long jobSeekerId, short skillId)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobSeekerId.Equals(jobSeekerId) && t.SkillId.Equals(skillId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }
        public async Task<List<JobSeekerEssentialSkills>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobSeekerEssentialSkills
            { 
                JobSeekerId = x.JobSeekerId,
                SkillId = x.SkillId
                
            }).ToListAsync();
        }
        public async Task<List<JobSeekerEssentialSkills>> GetJobSeekerEssentialSkillsByIdAsync(long id)
        {
           return await base.TableNoTracking.Include(x=>x.Skill).Where(x => x.JobSeekerId.Equals(id)).ToListAsync();
        }
        public async Task<JobSeekerEssentialSkills> UpdateJobSeekerEssentialSkillsAsync(JobSeekerEssentialSkills jobSeekerEssentialSkills)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobSeekerId.Equals(jobSeekerEssentialSkills.JobSeekerId)).FirstOrDefaultAsync();

            if (fetchedJobEssentialSkills == null) return null;
            await base.UpdateAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }
    }
}
 