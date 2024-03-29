﻿using Application.Contracts.ReadPersistence;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;

namespace Persistence.ReadRepositories
{
    public class ReadEmployerRepository : BaseReadRepository<Employer>, IReadEmployerRepository
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
        public async Task<List<Employer>> FilterByTerm(string term,long userId,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return await base.GetWithFilterAsync(x=> x.DefinerId == userId);
            }
            return await base.GetWithFilterAsync(x => (x.DefinerId == userId) && (x.FirstName.Contains(term) || x.LastName.Contains(term) || x.Email.Contains(term)));
        }
    }
}
