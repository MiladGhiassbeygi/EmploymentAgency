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
        //public Task DeleteByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
        //{
        //    return base.DeleteAsync(m => m.MovieId == movieId, cancellationToken);
        //}
    }
}
