using Application.Contracts.Persistence;
using Persistence.Repositories.Employer;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Persistence.Repositories.JobRepositories;

namespace Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
            CountryRepository = new CountryRepository(_db);
            SuccessedContractRepository = new SuccessedContractRepository(_db);
            JobRepository = new JobRepository(_db);
            JobCommissionRepository = new JobCommissionRepository(_db);
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
