using Domain.WriteModel;

namespace Application.Contracts.WritePersistence
{
    public interface IWorkExperienceSkillRepository
    {
        Task<WorkExperienceSkill> CreateWorkExperienceSkillAsync(WorkExperienceSkill workExperienceSkill);
        Task<List<WorkExperienceSkill>> GetWorkExperienceSkillByIdAsync(int id);
        Task<WorkExperienceSkill> UpdateWorkExperienceSkillAsync(WorkExperienceSkill workExperienceSkill);
        Task<WorkExperienceSkill> DeleteWorkExperienceSkillByIdAsync(int id);
        Task<List<WorkExperienceSkill>> GetAll();
    }
}
