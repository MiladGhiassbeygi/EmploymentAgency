using MongoDB.Driver;
using Persistence.ReadRepositories.Common;
using Domain.ReadModel;
using Application.Contracts.ReadPersistence.Account;

namespace Persistence.ReadRepositories
{
    
    public class ReadAccountRepository : BaseReadRepository<User>, IReadAccountRepository
    {
        public ReadAccountRepository(IMongoDatabase db) : base(db)
        {
        }
        
    }
}
