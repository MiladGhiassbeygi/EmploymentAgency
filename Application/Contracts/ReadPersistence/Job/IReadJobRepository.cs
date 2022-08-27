using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadJobRepository : IReadBaseRepository<Job>
    {
        Task<List<Job>> FilterByTerm(string term,long userId,CancellationToken cancellationToken);
    }
}
