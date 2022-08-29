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
    }
}
