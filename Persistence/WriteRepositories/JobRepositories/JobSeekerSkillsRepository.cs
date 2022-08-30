using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

 namespace Persistence.WriteRepositories
{
    internal class JobSeekerSkillsRepository : BaseAsyncRepository<JobSeekerSkills>, IJobSeekerSkillsRepository
    {
        public JobSeekerSkillsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<JobSeekerSkills> CreateJobSeekerSkillsAsync(JobSeekerSkills JobSeekerSkills)
        {
            var newJobSeekerSkills = JobSeekerSkills;
            await base.AddAsync(newJobSeekerSkills);
            return newJobSeekerSkills;
        }

        public async Task<JobSeekerSkills> DeleteJobSeekerSkillsByIdAsync(long jobSeekerId , short SkillId)
        {
            var fetchedJobSeekerSkills = await base.Table.Where(t => t.JobSeekerId.Equals(jobSeekerId) && t.SkillId.Equals(SkillId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobSeekerSkills);
            return fetchedJobSeekerSkills;
        }
        public async Task<List<JobSeekerSkills>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobSeekerSkills
            { 
                JobSeekerId = x.JobSeekerId,
                SkillId = x.SkillId
                
            }).ToListAsync();
        }

        public async Task<List<JobSeekerSkills>> GetJobSeekerSkillsByIdAsync(long id)
        {
           return await base.TableNoTracking.Include(x=>x.Skill).Where(x => x.JobSeekerId.Equals(id)).ToListAsync();
        }

        public async Task<JobSeekerSkills> UpdateJobSeekerSkillsAsync(JobSeekerSkills JobSeekerSkills)
        {
            var fetchedJobSeekerSkills = await base.Table.Where(t => t.JobSeekerId.Equals(JobSeekerSkills.JobSeekerId)).FirstOrDefaultAsync();

            if (fetchedJobSeekerSkills == null) return null;
            await base.UpdateAsync(fetchedJobSeekerSkills);
            return fetchedJobSeekerSkills;
        }
    }
}
 