using Application.Contracts.Persistence.JobContract;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;


namespace Persistence.WriteRepositories
{
    internal class JobSeekerRepository : BaseAsyncRepository<JobSeeker>, IJobSeekerRepository
    {
        public JobSeekerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<JobSeeker> IsExist(string firstName, string lastName)
        {
            return await base.TableNoTracking
                                .FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }
        public async Task<JobSeeker> CreateJobSeekerAcync(JobSeeker jobSeeker, short[] essentialSkillIds, short[] unnessecarySkillIds)
        {
            var newJobSeeker = jobSeeker;
            await base.AddAsync(newJobSeeker);
            DbContext.SaveChanges();
            foreach (var skillId in essentialSkillIds)
            {
                var essential = new JobSeekerEssentialSkills()
                {
                    SkillId = skillId,
                    JobSeekerId = newJobSeeker.Id
                };
                await DbContext.Set<JobSeekerEssentialSkills>().AddAsync(essential);
            }
            foreach (var skillId in unnessecarySkillIds)
            {
                var unnessecary = new JobSeekerUnnessecarySkills()
                {
                    SkillId = skillId,
                    JobSeekerId = newJobSeeker.Id
                };
                await DbContext.Set<JobSeekerUnnessecarySkills>().AddAsync(unnessecary);
            }


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
                ResumeFilePath = x.ResumeFilePath,
                DefinerId = x.DefinerId
            }).ToListAsync();
        }

        public async Task<JobSeeker> GetJobSeekerByIdAsync(long id)
        {
            var jobSeeker = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return jobSeeker;
        }

        public async Task<JobSeeker> UpdateJobSeekerAsync(JobSeeker jobSeeker)
        {

            await base.UpdateAsync(jobSeeker);
            return jobSeeker;
        }
    }
}

