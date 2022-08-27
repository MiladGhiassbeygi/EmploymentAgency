using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadEmployerRepository : IReadBaseRepository<Employer>
    {
        Task<List<Employer>> FilterByTerm(string term,long userId,CancellationToken cancellationToken);
    }
}
