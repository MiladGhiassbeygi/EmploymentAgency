using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.WritePersistence
{
    public interface IEducationalBackgroundRepository
    {
        Task<EducationalBackground> CreateEducationalBackgroundAsync(EducationalBackground educationalBackground);
        Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id);
        Task<EducationalBackground> UpdateEducationalBackgroundAsync(EducationalBackground educationalBackground);
        Task<EducationalBackground> DeleteEducationalBackgroundByIdAsync(int id);
        Task<List<EducationalBackground>> GetAll();
    }
}
