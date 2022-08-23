using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;


namespace Persistence.ReadRepositories
{
    public class ReadEducationalBackgroundRepository : BaseReadRepository<EducationalBackground>, IReadEducationalBackgroundRepository
    {
        public ReadEducationalBackgroundRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.EducationalBackgroundId == id, cancellationToken);
        }

        public async Task<List<EducationalBackground>> GetEducationalBackgrounds()
        {
            return await base.GetAllAsync();
        }
      
    }
}