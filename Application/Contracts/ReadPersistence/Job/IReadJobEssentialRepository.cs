using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadJobEssentialRepository : IReadBaseRepository<JobEssentialSkills>
    {
        Task<List<JobEssentialSkills>> GetJobSkillsWithJobIdAsync(long jobId);
    }
}
