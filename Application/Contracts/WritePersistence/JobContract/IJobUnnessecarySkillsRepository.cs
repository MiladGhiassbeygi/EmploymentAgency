using Domain.WriteModel;


namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobUnnessecarySkillsRepository
    {
        Task<JobUnnecessarySkills> CreateJobUnnessecarySkillsAsync(JobUnnecessarySkills jobUnnecessarySkills);
        Task<List<JobUnnecessarySkills>> GetJobUnnessecarySkillsByIdAsync(long id);
        Task<JobUnnecessarySkills> UpdateJobUnnessecarySkillsAsync(JobUnnecessarySkills jobUnnecessarySkills);
        Task<JobUnnecessarySkills> DeleteJobUnnessecarySkillsByIdAsync(long id);
        Task<List<JobUnnecessarySkills>> GetAll();
    }
}
