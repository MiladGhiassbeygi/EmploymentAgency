using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadJobSeekerRepository : BaseReadRepository<JobSeeker>, IReadJobSeekerRepository
    {
        public ReadJobSeekerRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<JobSeeker> GetJobSeekerByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.JobSeekerId == id, cancellationToken);
        }

        public Task<JobSeeker> GetJobSeekerByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.FirstName + x.LastName == name, cancellationToken);
        }

        public async Task<List<JobSeeker>> GetJobSeekers()
        {
            return await base.GetAllAsync();
        }

        public async Task<List<JobSeeker>> FilterByTerm(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return await base.GetAllAsync();
            }
            return await base.GetWithFilterAsync(x => x.FirstName.Contains(term) ||x.LastName.Contains(term) || x.LinkedinAddress.Contains(term) ||x.Email.Contains(term));
        }
    }
}
