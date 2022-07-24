using Application.Contracts.Persistence;
using Persistence.Repositories.Employer;

namespace Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
            CountryRepository = new CountryRepository(_db);
            EmployerAcivityFieldRepository = new EmployerAcivityFieldRepository(_db);

        }

        public Task CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        public ValueTask RollBackAsync()
        {
            return _db.DisposeAsync();
        }
    }
}
