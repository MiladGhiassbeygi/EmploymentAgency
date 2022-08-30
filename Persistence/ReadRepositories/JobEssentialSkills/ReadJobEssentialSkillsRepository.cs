using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadJobEssentialSkillsRepository : BaseReadRepository<JobEssentialSkills>, IReadJobEssentialSkillsRepository
    {
        public ReadJobEssentialSkillsRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<JobEssentialSkills> GetJobEssentialSkillsBySkilIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.SkillId == id, cancellationToken);
        }

        public async Task<List<JobEssentialSkills>> GetJobEssentialSkillsSkills()
        {
            return await base.GetAllAsync();
        }
    }
}
