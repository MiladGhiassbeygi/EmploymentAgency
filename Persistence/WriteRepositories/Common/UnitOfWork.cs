using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.WritePersistence;
using MongoDB.Driver;
using Persistence.ReadRepositories;
using Persistence.ReadRepositories.Area;
using Persistence.WriteRepositories.JobRepositories;

namespace Persistence.WriteRepositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMongoDatabase _readDb;

        public IReadCountryRepository ReadCountryRepository { get; }
        public IReadJobSeekerRepository ReadJobSeekerRepository { get; }
        public IReadJobRepository ReadJobRepository { get; }
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }
        public IEmployerRepository EmployerRepository { get; }
        public IReadEmployerRepository ReadEmployerRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }

        public IJobSeekerRepository JobSeekerRepository { get; }

        public UnitOfWork(ApplicationDbContext db, IMongoDatabase readDb)
        {
            _db = db;
            _readDb = readDb;
            ReadCountryRepository = new ReadCountryRepository(_readDb);
            ReadJobSeekerRepository = new ReadJobSeekerRepository(_readDb);
            ReadJobRepository = new ReadJobRepository(_readDb);
            UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
            CountryRepository = new CountryRepository(_db);
            SuccessedContractRepository = new SuccessedContractRepository(_db);
            JobRepository = new JobRepository(_db);
            JobCommissionRepository = new JobCommissionRepository(_db);
            SkillRepository = new SkillRepository(_db);
            JobEssentialSkillsRepository = new JobEssentialSkillsRepository(_db);
            EmployerRepository = new EmployerRepository(_db);
            EmployerAcivityFieldRepository = new EmployerAcivityFieldRepository(_db);
            JobSeekerRepository = new JobSeekerRepository(_db);
            ReadEmployerRepository = new ReadEmployerRepository(_readDb);

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
