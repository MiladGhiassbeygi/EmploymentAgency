using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadJobSeekerSkillsRepository : BaseReadRepository<JobSeekerSkills>, IReadJobSeekerSkillsRepository
    {
        public ReadJobSeekerSkillsRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<JobSeekerSkills> GetJobSeekerSkillByIdAsync(long jobSeekerId,short skillId, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.JobSeekerId == jobSeekerId && x.SkillId == skillId, cancellationToken);
        }
        public async Task<List<JobSeekerSkills>> GetJobSeekerSkills(long jobSeekerId)
        {
            return await base.GetWithFilterAsync(x=> x.JobSeekerId == jobSeekerId);
        }
        
    }
}
