using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadWorkExperienceRepository : BaseReadRepository<WorkExperience>, IReadWorkExperienceRepository
    {
        public ReadWorkExperienceRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<WorkExperience> GetWorkExperienceByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.WorkExperienceId == id, cancellationToken);
        }

        public async Task<List<WorkExperience>> GetWorkExperiences()
        {
            return await base.GetAllAsync();
        }
    }
}