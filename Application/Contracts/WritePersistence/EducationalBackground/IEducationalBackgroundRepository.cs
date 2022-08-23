using Domain.WriteModel;

namespace Application.Contracts.WritePersistence
{
    public interface IEducationalBackgroundRepository
    {
        Task<EducationalBackground> CreateEducationalBackgroundAsync(EducationalBackground EducationalBackground);
        Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id);
        Task<EducationalBackground> UpdateEducationalBackgroundAsync(EducationalBackground EducationalBackground);
        Task<EducationalBackground> DeleteEducationalBackgroundByIdAsync(int id);
        Task<List<EducationalBackground>> GetAll();
    }
}
