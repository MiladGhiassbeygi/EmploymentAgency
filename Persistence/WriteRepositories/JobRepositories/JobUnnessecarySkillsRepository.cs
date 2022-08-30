using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

 namespace Persistence.WriteRepositories
{
    internal class JobUnnessecarySkillsRepository : BaseAsyncRepository<JobUnnessecarySkills>, IJobUnnessecarySkillsRepository
    {
        public JobUnnessecarySkillsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<JobUnnessecarySkills> CreateJobUnnessecarySkillsAsync(JobUnnessecarySkills JobUnnessecarySkills)
        {
            var newJobUnnessecarySkills = JobUnnessecarySkills;
            await base.AddAsync(newJobUnnessecarySkills);
            return newJobUnnessecarySkills;
        }

        public async Task<JobUnnessecarySkills> DeleteJobUnnessecarySkillsByIdAsync(long jobId , short SkillId)
        {
            var fetchedJobUnnessecarySkills = await base.Table.Where(t => t.JobId.Equals(jobId) && t.SkillId.Equals(SkillId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobUnnessecarySkills);
            return fetchedJobUnnessecarySkills;
        }

        public async Task<List<JobUnnessecarySkills>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobUnnessecarySkills
            { 
                JobId = x.JobId,
                SkillId = x.SkillId
                
            }).ToListAsync();
        }

        public async Task<List<JobUnnessecarySkills>> GetJobUnnessecarySkillsByIdAsync(long id)
        {
           return await base.TableNoTracking.Include(x=> x.Skill).Where(x => x.JobId.Equals(id)).ToListAsync();
        }

        public async Task<JobUnnessecarySkills> UpdateJobUnnessecarySkillsAsync(JobUnnessecarySkills JobUnnessecarySkills)
        {
            var fetchedJobUnnessecarySkills = await base.Table.Where(t => t.JobId.Equals(JobUnnessecarySkills.JobId)).FirstOrDefaultAsync();

            if (fetchedJobUnnessecarySkills == null) return null;
            await base.UpdateAsync(fetchedJobUnnessecarySkills);
            return fetchedJobUnnessecarySkills;
        }
    }
}
 