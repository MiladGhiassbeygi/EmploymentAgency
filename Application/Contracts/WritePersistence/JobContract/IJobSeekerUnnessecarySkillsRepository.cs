using Domain.WriteModel;


namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobSeekerUnnessecarySkillsRepository
    {
        Task<JobSeekerUnnessecarySkills> CreateJobSeekerUnnessecarySkillsAsync(JobSeekerUnnessecarySkills jobUnnecessarySkills);
        Task<List<JobSeekerUnnessecarySkills>> GetJobSeekerUnnessecarySkillsByIdAsync(long id);
        Task<JobSeekerUnnessecarySkills> UpdateJobSeekerUnnessecarySkillsAsync(JobSeekerUnnessecarySkills jobUnnecessarySkills);
        Task<JobSeekerUnnessecarySkills> DeleteJobSeekerUnnessecarySkillsByIdAsync(long jobId,short skillId);
        Task<List<JobSeekerUnnessecarySkills>> GetAll();
    }
}
