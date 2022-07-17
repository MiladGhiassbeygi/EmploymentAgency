using Domain.Entities.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICountryRepository
    {
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByTitleAsync(string title);
        Task<Country> UpdateCountryAsync(Country country);
        Task<Country> DeleteCountryByIdAsync(int id);
    }
}
