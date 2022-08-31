using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories.JobRepositories
{
    internal class JobCommissionRepository : BaseAsyncRepository<JobCommission>, IJobCommissionRepository
    {
        public JobCommissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<JobCommission> CreateJobCommissionAsync(JobCommission jobCommission)
        {
            var newJobCommission = jobCommission;
            await base.AddAsync(newJobCommission);
            return newJobCommission;

        }
        public async Task<JobCommission> GetJobCommissionByIdAsync(long id)
        {
            var jobCommission = await base.TableNoTracking.FirstOrDefaultAsync(x => x.JobId.Equals(id));
            return jobCommission;
        }
       
        public async Task<JobCommission> UpdateJobCommissionAsync(JobCommission jobCommission)
        {
            await base.UpdateAsync(jobCommission);
            return jobCommission;
        }
        public async Task<JobCommission> DeleteJobCommissionByIdAsync(long id)
        {

            var fetchedJobCommission = await base.Table.Where(t => t.JobId.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobCommission);
            return fetchedJobCommission;
        }
        public async Task<List<JobCommission>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobCommission
            {
                JobId = x.Id,
                IsFixed = x.IsFixed,
                Value = x.Value,

            }).ToListAsync();
        }
    }
}
