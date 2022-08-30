using Domain.WriteModel;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobSeekerEssentialSkillsRepository
    {
        Task<JobSeekerEssentialSkills> CreateJobSeekerEssentialSkillsAsync(JobSeekerEssentialSkills jobSeekerEssentialSkills);
        Task<List<JobSeekerEssentialSkills>> GetJobSeekerEssentialSkillsByIdAsync(long id);
        Task<JobSeekerEssentialSkills> UpdateJobSeekerEssentialSkillsAsync(JobSeekerEssentialSkills jobSeekerEssentialSkills);
        Task<JobSeekerEssentialSkills> DeleteJobSeekerEssentialSkillsByIdAsync(long jobSeekerId,short skillId);
        Task<List<JobSeekerEssentialSkills>> GetAll();

    }
}
