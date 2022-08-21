using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.WritePersistence
{
    public interface IWorkExperienceRepository
    {
        Task<WorkExperience> CreateWorkExperienceAsync(WorkExperience workExperience);
        Task<WorkExperience> GetWorkExperienceByIdAsync(int id);
        Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience);
        Task<WorkExperience> DeleteWorkExperienceByIdAsync(int id);
        Task<List<WorkExperience>> GetAll();
    }
}
