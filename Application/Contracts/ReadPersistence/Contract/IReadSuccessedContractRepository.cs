using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadSuccessedContractRepository :IReadBaseRepository<SuccessedContract>
    {
        Task<List<SuccessedContract>> FilterByTerm(string term, long userId, CancellationToken cancellationToken);
    }
}
