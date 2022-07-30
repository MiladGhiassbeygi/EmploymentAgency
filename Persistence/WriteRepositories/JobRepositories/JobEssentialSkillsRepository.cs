using Application.Contracts.Persistence;
using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

 namespace Persistence.WriteRepositories
{
    internal class JobEssentialSkillsRepository : BaseAsyncRepository<JobEssentialSkills>, IJobEssentialSkillsRepository
    {
        public JobEssentialSkillsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<JobEssentialSkills> CreateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills)
        {
            var newJobEssentialSkills = jobEssentialSkills;
            await base.AddAsync(newJobEssentialSkills);
            return newJobEssentialSkills;
        }

        public async Task<JobEssentialSkills> DeleteJobEssentialSkillsByIdAsync(long jobId , short SkillId)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobId.Equals(jobId) && t.SkillId.Equals(SkillId)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }

        public Task<JobEssentialSkills> DeleteJobEssentialSkillsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobEssentialSkills>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobEssentialSkills
            { 
                JobId = x.JobId,
                SkillId = x.SkillId
                
            }).ToListAsync();
        }

        public async Task<JobEssentialSkills> GetJobEssentialSkillsByIdAsync(int id)
        {
            var jobEssentialSkills = await base.TableNoTracking.FirstOrDefaultAsync(x => x.JobId.Equals(id));
            return jobEssentialSkills;
        }

        public async Task<JobEssentialSkills> UpdateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills)
        {
            var fetchedJobEssentialSkills = await base.Table.Where(t => t.JobId.Equals(jobEssentialSkills.JobId)).FirstOrDefaultAsync();

            if (fetchedJobEssentialSkills == null) return null;
            await base.UpdateAsync(fetchedJobEssentialSkills);
            return fetchedJobEssentialSkills;
        }
    }
}
 