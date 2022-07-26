using Domain.WriteModel;

namespace Application.Contracts.Persistence.Area
{
    public interface ICountryRepository
    {
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByTitleAsync(string title);
        Task<Country> UpdateCountryAsync(Country country);
        Task<Country> DeleteCountryByIdAsync(int id);
        Task<List<Country>> GetAll();
    }
}
