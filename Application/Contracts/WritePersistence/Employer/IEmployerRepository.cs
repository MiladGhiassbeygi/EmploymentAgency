using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.WritePersistence
{
    public interface IEmployerRepository
    {
        Task<Employer> CreateEmployerAsync(Employer employer);
        Task<Employer> GetEmployerByIdAsync(long id);
        Task<Employer> GetEmployerByNameAsync(string firstName,string lastName);
        Task<Employer> UpdateEmployerAsync(Employer employer);
        Task<Employer> DeleteEmployerByIdAsync(long id);
        Task<List<Employer>> GetAll();
    }
}
