using Application.Contracts.Persistence;
using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;


namespace Persistence.WriteRepositories
{
    internal class JobSeekerRepository : BaseAsyncRepository<JobSeeker>, IJobSeekerRepository
    {
        public JobSeekerRepository (ApplicationDbContext dbContext): base(dbContext)
        {

        }

        public async Task<JobSeeker> IsExist(string firstName, string lastName)
        {
            return await base.TableNoTracking
                                .FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }
        public async Task<JobSeeker> CreateJobSeekerAcync(JobSeeker jobSeeker)
        {
            var newJobSeeker = jobSeeker;
            await base.AddAsync(newJobSeeker);
            return newJobSeeker;
        }

        public async Task<JobSeeker> DeleteJobSeekerByIdAsync(long id)
        {
            var fetchedJobSeeker = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedJobSeeker);
            return fetchedJobSeeker;
        }

        public async Task<List<JobSeeker>> GetAll()
        {
            return await base.TableNoTracking.Select(x => new JobSeeker
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CountryId = x.CountryId,
                Email = x.Email,
                LinkedinAddress = x.LinkedinAddress,
                ResumeFilePath = x.ResumeFilePath
            }).ToListAsync();
        }

        public async Task<JobSeeker> GetJobSeekerByIdAsync(long id)
        {
            var jobSeeker = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return jobSeeker;
        }

        public async Task<JobSeeker> UpdateJobSeekerAsync(JobSeeker jobSeeker)
        {
            var fetchedJobSeeker = await base.Table.Where(t => t.Id.Equals(jobSeeker.Id)).FirstOrDefaultAsync();

            if (fetchedJobSeeker == null) return null;
            await base.UpdateAsync(fetchedJobSeeker);
            return fetchedJobSeeker;
        }
    }
 }

