using Domain.WriteModel;


namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobUnnessecarySkillsRepository
    {
        Task<JobUnnecessarySkills> CreateJobUnnessecarySkillsAsync(JobUnnecessarySkills jobUnnecessarySkills);
        Task<JobUnnecessarySkills> GetJobUnnessecarySkillsByIdAsync(int id);
        Task<JobUnnecessarySkills> UpdateJobUnnessecarySkillsAsync(JobUnnecessarySkills jobUnnecessarySkills);
        Task<JobUnnecessarySkills> DeleteJobUnnessecarySkillsByIdAsync(int id);
        Task<List<JobUnnecessarySkills>> GetAll();
    }
}
