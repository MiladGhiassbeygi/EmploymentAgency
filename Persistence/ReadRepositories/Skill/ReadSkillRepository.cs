using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadSkillRepository : BaseReadRepository<Skill>, IReadSkillRepository
    {
        public ReadSkillRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<Skill> GetSkillByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.SkillId == id, cancellationToken);
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await base.GetAllAsync();
        }
        public async Task<bool> AnyListAsync(short[] skillIds)
        {
            var skillsCount = await base.Collection.CountDocumentsAsync(x => skillIds.Contains(x.SkillId));
            if (skillsCount == skillIds.Count())
                return true;
            return false;
        }
    }
}
