using Domain.WriteModel;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobSeekerSkillsRepository
    {
        Task<JobSeekerSkills> CreateJobSeekerSkillsAsync(JobSeekerSkills JobSeekerSkills);
        Task<List<JobSeekerSkills>> GetJobSeekerSkillsByIdAsync(long id);
        Task<JobSeekerSkills> UpdateJobSeekerSkillsAsync(JobSeekerSkills JobSeekerSkills);
        Task<JobSeekerSkills> DeleteJobSeekerSkillsByIdAsync(long jobId,short skillId);
        Task<List<JobSeekerSkills>> GetAll();

    }
}
