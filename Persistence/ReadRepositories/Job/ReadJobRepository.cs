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

        public async Task<List<Job>> FilterByTerm(string term)
        {
            return await base.GetWithFilterAsync(x => x.Title.Contains(term) || x.Description.Contains(term));
        }


        //public Task DeleteByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
        //{
        //    return base.DeleteAsync(m => m.MovieId == movieId, cancellationToken);
        //}
    }
}
