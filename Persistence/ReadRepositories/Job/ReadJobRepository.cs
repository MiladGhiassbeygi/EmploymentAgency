using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;


namespace Persistence.ReadRepositories
{
    public class ReadJobRepository : BaseReadRepository<Job>, IReadJobRepository
    {
        public ReadJobRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<Job> GetJobByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.JobId == id, cancellationToken);
        }

        public Task<Job> GetJobByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.Title == title, cancellationToken);
        }

        public async Task<List<Job>> GetJobs()
        {
            return await base.GetAllAsync();
        }

        public async Task<List<Job>> FilterByTerm(string term, long userId,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return await base.GetWithFilterAsync(x=> x.DefinerId == userId);
            }
            return await base.GetWithFilterAsync(x => (x.DefinerId == userId) && (x.Title.Contains(term) || x.Description.Contains(term)));
        }
    }
}
