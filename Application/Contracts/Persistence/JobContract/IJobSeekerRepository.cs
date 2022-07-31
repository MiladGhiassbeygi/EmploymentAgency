using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobSeekerRepository
    {
        Task<JobSeeker> CreateJobSeekerAcync(JobSeeker jobSeeker);
        Task<JobSeeker> GetJobSeekerByIdAsync(long id);
        Task<JobSeeker> UpdateJobSeekerAsync(JobSeeker jobSeeker);
        Task<JobSeeker> DeleteJobSeekerByIdAsync(long id);
        Task<List<JobSeeker>> GetAll();
    }
}
