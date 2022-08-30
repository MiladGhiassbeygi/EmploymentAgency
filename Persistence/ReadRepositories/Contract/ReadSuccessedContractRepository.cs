using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories.Contract
{
    internal class ReadSuccessedContractRepository : BaseReadRepository<SuccessedContract>, IReadSuccessedContractRepository
    {
        public ReadSuccessedContractRepository(IMongoDatabase db) : base(db)
        {
        }

        public async Task<List<SuccessedContract>> FilterByTerm(string term, long userId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return await base.GetWithFilterAsync(x => x.ContractCreatorId == userId);
            }
            return await base.GetWithFilterAsync(x => (x.ContractCreatorId == userId));
        }
        public async Task<List<SuccessedContract>> GetSuccessedContracts()
        {
            return await base.GetAllAsync();
        }
        public Task<SuccessedContract> GetSuccessedContractByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.SuccessedContractId == id, cancellationToken);
        }
        public async Task<List<SuccessedContract>> GetHiredPeopleSearch(long jobId,long jobSeekerId,long employerId,CancellationToken cancellationToken)
        {
            return await base.GetWithFilterAsync(x => (jobId == 0 || x.JobId == jobId) && (jobSeekerId == 0 || x.JobSeekerId == jobSeekerId)
                                            && (employerId == 0 && x.EmployerId == employerId));
        }
    }
}
