using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

 namespace Persistence.WriteRepositories
{
    internal class JobSeekerUnnessecarySkillsRepository : BaseAsyncRepository<JobSeekerUnnessecarySkills>, IJobSeekerUnnessecarySkillsRepository
    {
        public JobSeekerUnnessecarySkillsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        
        public async Task<JobSeekerUnnessecarySkills> CreateJobSeekerUnnessecarySkillsAsync(JobSeekerUnnessecarySkills JobSeekerUnnessecarySkills)
        {
            var newJobEssentialSkills = JobSeekerUnnessecarySkills;
            await base.AddAsync(newJobEssentialSkills);
            return newJobEssentialSkills;
        }
        public async Task<JobSeekerUnnessecarySkills> DeleteJobSeekerUnnessecarySkillsByIdAsync(long jobSeekerId, short skillId)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobSeekerId.Equals(jobSeekerId) && t.SkillId.Equals(skillId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }
        public async Task<List<JobSeekerUnnessecarySkills>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobSeekerUnnessecarySkills
            { 
                JobSeekerId = x.JobSeekerId,
                SkillId = x.SkillId
                
            }).ToListAsync();
        }
        public async Task<List<JobSeekerUnnessecarySkills>> GetJobSeekerUnnessecarySkillsByIdAsync(long id)
        {
           return await base.TableNoTracking.Include(x=>x.Skill).Where(x => x.JobSeekerId.Equals(id)).ToListAsync();
        }
        public async Task<JobSeekerUnnessecarySkills> UpdateJobSeekerUnnessecarySkillsAsync(JobSeekerUnnessecarySkills JobSeekerUnnessecarySkills)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobSeekerId.Equals(JobSeekerUnnessecarySkills.JobSeekerId)).FirstOrDefaultAsync();

            if (fetchedJobEssentialSkills == null) return null;
            await base.UpdateAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }
    }
}
 