using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;
using System.Collections.Generic;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadEmployerRepository : IReadBaseRepository<Employer>
    {
        Task<List<Employer>> FilterByTerm(string term);
    }
}
