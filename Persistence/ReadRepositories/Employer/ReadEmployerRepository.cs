using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ReadRepositories
{
    public class ReadEmployerRepository : BaseReadRepository<Employer>,IReadEmployerRepository
    {
        public ReadEmployerRepository(IMongoDatabase db) : base(db)
        {

        }
        public Task<Employer> GetEmployerByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.EmployerId == id, cancellationToken);
        }
        public async Task<List<Employer>> GetEmployers()
        {
            return await base.GetAllAsync();
        }
    }
}
