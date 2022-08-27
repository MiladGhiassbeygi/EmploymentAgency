using Domain.WriteModel;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobEssentialSkillsRepository
    {
        Task<JobEssentialSkills> CreateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills);
        Task<List<JobEssentialSkills>> GetJobEssentialSkillsByIdAsync(long id);
        Task<JobEssentialSkills> UpdateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills);
        Task<JobEssentialSkills> DeleteJobEssentialSkillsByIdAsync(long jobId,short skillId);
        Task<List<JobEssentialSkills>> GetAll();

    }
}
