using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.JobContract
{
    public interface IJobEssentialSkillsRepository
    {
        Task<JobEssentialSkills> CreateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills);
        Task<JobEssentialSkills> GetJobEssentialSkillsByIdAsync(int id);
        Task<JobEssentialSkills> UpdateJobEssentialSkillsAsync(JobEssentialSkills jobEssentialSkills);
        Task<JobEssentialSkills> DeleteJobEssentialSkillsByIdAsync(int id);
        Task<List<JobEssentialSkills>> GetAll();
    }
}
