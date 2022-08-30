using Domain.WriteModel;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobSeekerRepository
    {
        Task<JobSeeker> CreateJobSeekerAcync(JobSeeker jobSeeker);
        Task<JobSeeker> GetJobSeekerByIdAsync(long id);
        Task<JobSeeker> IsExist(string firstName,string lastName);
        Task<JobSeeker> UpdateJobSeekerAsync(JobSeeker jobSeeker);
        Task<JobSeeker> DeleteJobSeekerByIdAsync(long id);
        Task<List<JobSeeker>> GetAll();
    }
}
