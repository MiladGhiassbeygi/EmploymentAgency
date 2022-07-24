using Application.Contracts.Persistence.JobContract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.JobRepositories
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
        public async Task<JobCommission> GetJobCommissionByIdAsync(int id)
        {
            var jobCommission = await base.TableNoTracking.FirstOrDefaultAsync(x => x.JobId.Equals(id));
            return jobCommission;
        }
       
        public async Task<JobCommission> UpdateJobCommissionAsync(JobCommission jobCommission)
        {
            var fetchedJobCommission = await base.Table.Where(t => t.Id.Equals(jobCommission.JobId)).FirstOrDefaultAsync();

            if (fetchedJobCommission == null) return null;
            await base.UpdateAsync(fetchedJobCommission);
            return fetchedJobCommission;
        }
        public async Task<JobCommission> DeleteJobCommissionByIdAsync(int id)
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
