using Application.Contracts.Persistence.Area;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

namespace Persistence.WriteRepositories
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
            await base.UpdateAsync(country);
            return country;
        }
        public async Task<Country> DeleteCountryByIdAsync(int id) {

            var fetchedCountry = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            
            await base.DeleteAsync(fetchedCountry);
            return fetchedCountry;
        }
        public async Task<List<Country>> GetAll()
        {
            return await base.TableNoTracking.Select(x=> new Country {Id = x.Id, Title = x.Title,AreaCode = x.AreaCode,PostalCode = x.PostalCode }).ToListAsync();
        }
    }
}


