using Domain.WriteModel;


namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobUnnessecarySkillsRepository
    {
        Task<JobUnnessecarySkills> CreateJobUnnessecarySkillsAsync(JobUnnessecarySkills jobUnnessecarySkills);
        Task<List<JobUnnessecarySkills>> GetJobUnnessecarySkillsByIdAsync(long id);
        Task<JobUnnessecarySkills> UpdateJobUnnessecarySkillsAsync(JobUnnessecarySkills jobUnnessecarySkills);
        Task<JobUnnessecarySkills> DeleteJobUnnessecarySkillsByIdAsync(long jobId,short skillId);
        Task<List<JobUnnessecarySkills>> GetAll();
    }
}
