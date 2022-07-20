using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    internal class CountryRepository : BaseAsyncRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            var newCountry = country;
            await base.AddAsync(newCountry);
            return newCountry;

        }
        public async Task<Country> GetCountryByIdAsync(int id)
        {
            var country = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return country;
        }
        public async Task<Country> GetCountryByTitleAsync(string title)
        {
            var country = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return country;
        }
        public async Task<Country> UpdateCountryAsync(Country country)
        {
            var fetchedCountry = await base.Table.Where(t => t.Id.Equals(country.Id)).FirstOrDefaultAsync();

            if (fetchedCountry == null) return null;
            await base.UpdateAsync(fetchedCountry);
            return fetchedCountry;
        }
        public async Task<Country> DeleteCountryByIdAsync(int id) {

            var fetchedCountry = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            
            await base.DeleteAsync(fetchedCountry);
            return fetchedCountry;
        }
    }
}


