using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadSuccessedContractRepository :IReadBaseRepository<SuccessedContract>
    {
        Task<List<SuccessedContract>> FilterByTerm(string term, long userId, CancellationToken cancellationToken);
        Task<List<SuccessedContract>> GetHiredPeopleSearch(long jobId, long jobSeekerId, long employerId, CancellationToken cancellationToken);
    }
}
