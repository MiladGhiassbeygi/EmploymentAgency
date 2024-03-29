﻿using Application.Contracts.Persistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
{
    internal class JobRepository : BaseAsyncRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            var newJob = job;
            await base.AddAsync(newJob);
            return newJob;

        }
        public async Task<Job> GetJobByIdAsync(long id)
        {
            var job = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return job;
        }
        public async Task<Job> GetJobByIdAggregateAsync(long id)
        {
            var job = await base.TableNoTracking.Include(x => x.JobEssentialSkills).Include(x => x.JobUnnecessarySkills).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return job;
        }
        public async Task<Job> GetJobAggregateByIdAsync(long id)
        {
            return await base.Entities.Where(x => x.Id == id)
                           .Include(x => x.JobCommission)
                           .Include(x => x.JobEssentialSkills).Include(x => x.JobUnnecessarySkills)
                           .Include(x => x.SuccessedContract)
                           .FirstOrDefaultAsync();
        }
        public async Task<Job> GetJobByTitleAsync(string title)
        {
            var job = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return job;
        }
        public async Task<Job> UpdateJobAsync(Job job)
        {
            var fetchedJob = await base.Table.Where(t => t.Id.Equals(job.Id)).FirstOrDefaultAsync();

            if (fetchedJob == null) return null;
            await base.UpdateAsync(fetchedJob);
            return fetchedJob;
        }
        public async Task<Job> DeleteJobByIdAsync(long id)
        {

            var fetchedJob = await base.Table.Where(t => t.Id.Equals(id))
                .Include(x => x.JobEssentialSkills).Include(x => x.JobUnnecessarySkills)

                .FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJob);
            return fetchedJob;
        }
        public async Task<Job> DeleteJobAsync(Job job)
        {
            await base.DeleteAsync(job);
            return job;
        }
        public async Task<List<Job>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new Job
            { /*Id= x.Id,*/
                Title = x.Title,
                HoursOfWork = x.HoursOfWork,
                SalaryMin = x.SalaryMin,
                SalaryMax = x.SalaryMax,
                AnnualLeave = x.AnnualLeave,
                ExactAmountRecived = x.ExactAmountRecived,
                Description = x.Description
            ,
                Email = x.Email,
                HireCompanies = x.HireCompanies,
                EmployerId = x.EmployerId
            }).ToListAsync();
        }
    }
}
