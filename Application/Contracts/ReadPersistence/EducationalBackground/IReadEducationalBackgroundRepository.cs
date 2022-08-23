using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadEducationalBackgroundRepository : IReadBaseRepository<EducationalBackground>
    {
        Task<List<EducationalBackground>> GetEducationalBackgrounds();
        Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
