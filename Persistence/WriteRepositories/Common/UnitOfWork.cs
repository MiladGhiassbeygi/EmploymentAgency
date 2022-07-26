using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence.Area;
using MongoDB.Driver;
using Persistence.ReadRepositories.Area;
using Persistence.WriteRepositories.JobRepositories;

namespace Persistence.WriteRepositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMongoDatabase _readDb;

        public IReadCountryRepository ReadCountryRepository { get; }
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }

        public UnitOfWork(ApplicationDbContext db, IMongoDatabase readDb)
        {
            _db = db;
            _readDb = readDb;
            ReadCountryRepository = new ReadCountryRepository(_readDb);
            UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
            CountryRepository = new CountryRepository(_db);
            SuccessedContractRepository = new SuccessedContractRepository(_db);
            JobRepository = new JobRepository(_db);
            JobCommissionRepository = new JobCommissionRepository(_db);
            SkillRepository = new SkillRepository(_db);
            JobEssentialSkillsRepository = new JobEssentialSkillsRepository(_db);

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
