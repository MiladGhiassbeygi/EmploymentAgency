using Application.Contracts.ReadPersistence.Area;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories.Area
{
  
    public class ReadCountryRepository : BaseReadRepository<Country>, IReadCountryRepository
    {
        public ReadCountryRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<Country> GetByCountryIdAsync(int countryId, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.CountryId == countryId, cancellationToken);
        }

        public Task<Country> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.Title == title, cancellationToken);
        }

        public async Task<List<Country>> GetCountries()
        {
            return await base.GetAllAsync();
        }
        //public Task DeleteByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
        //{
        //    return base.DeleteAsync(m => m.MovieId == movieId, cancellationToken);
        //}
    }
}
