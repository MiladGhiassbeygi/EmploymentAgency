using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;


namespace Persistence.ReadRepositories
{
    public class ReadJobEssentialRepository : BaseReadRepository<JobEssentialSkills>, IReadJobEssentialRepository
    {
        public ReadJobEssentialRepository(IMongoDatabase db) : base(db)
        {
        }
       
        public async Task<List<JobEssentialSkills>> GetJobSkillsWithJobIdAsync(long jobId)
        {
            return await base.GetWithFilterAsync(x => x.JobId == jobId);
        }
    }
}
