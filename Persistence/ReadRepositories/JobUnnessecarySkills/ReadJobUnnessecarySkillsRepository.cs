using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadJobUnnessecarySkillsRepository : BaseReadRepository<JobUnnecessarySkills>, IReadJobUnnessecarySkillsRepository
    {
        public ReadJobUnnessecarySkillsRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<JobUnnecessarySkills> GetJobUnnessecarySkillBySkilIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.SkillId == id, cancellationToken);
        }

        public async Task<List<JobUnnecessarySkills>> GetJobUnnessecarySkills()
        {
            return await base.GetAllAsync();
        }
    }
}
