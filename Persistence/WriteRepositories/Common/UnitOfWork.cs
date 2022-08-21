using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Application.Contracts.WritePersistence;
using Application.Contracts.WritePersistence.Reminder;
using MongoDB.Driver;
using Persistence.ReadRepositories;
using Persistence.ReadRepositories.Area;
using Persistence.ReadRepositories.ReadWorkExperience;
using Persistence.WriteRepositories.JobRepositories;
using Persistence.WriteRepositories.Reminder;

namespace Persistence.WriteRepositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMongoDatabase _readDb;


        #region ReadRepositories
        
        public IReadCountryRepository ReadCountryRepository { get; }
        public IReadJobSeekerRepository ReadJobSeekerRepository { get; }
        public IReadJobRepository ReadJobRepository { get; }
        public IReadReminderRepository ReadReminderRepository { get; }
        public IReadEmployerRepository ReadEmployerRepository { get; }
        public IReadEmployerActivitiesRepository ReadEmployerActivitiesRepository { get; }
        public IReadWorkExperienceRepository ReadWorkExperienceRepository { get; }
        public IReadSkillRepository ReadSkillRepository { get; }
        public IReadEducationalBackgroundRepository ReadEducationalBackgroundRepository { get; }

        #endregion

        #region WriteRepositories

        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }
        public IJobUnnessecarySkillsRepository JobUnnessecarySkillsRepository { get; }
        public IEmployerRepository EmployerRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }
        public IReminderRepository ReminderRepository { get; }
        public IJobSeekerRepository JobSeekerRepository { get; }
        public IWorkExperienceRepository WorkExperienceRepository { get; }
        public IWorkExperienceSkillRepository WorkExperienceSkillRepository { get; }
        public IEducationalBackgroundRepository EducationalBackgroundRepository { get; }

        #endregion

        public UnitOfWork(ApplicationDbContext db, IMongoDatabase readDb)
        {
            _db = db;
            _readDb = readDb;

            #region ReadRepositories

            ReadCountryRepository = new ReadCountryRepository(_readDb);
            ReadJobSeekerRepository = new ReadJobSeekerRepository(_readDb);
            ReadJobRepository = new ReadJobRepository(_readDb);
            ReadEmployerRepository = new ReadEmployerRepository(_readDb);
            ReadEmployerActivitiesRepository = new ReadEmployerActivitiesRepository(_readDb);
            ReadReminderRepository = new ReadReminderRepository(_readDb);
            ReadWorkExperienceRepository = new ReadWorkExperienceRepository(_readDb);
            ReadSkillRepository = new ReadSkillRepository(_readDb);
            ReadEducationalBackgroundRepository = new ReadEducationalBackgroundRepository(_readDb); 

            #endregion

            #region WriteRepositories

            UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
            CountryRepository = new CountryRepository(_db);
            SuccessedContractRepository = new SuccessedContractRepository(_db);
            JobRepository = new JobRepository(_db);
            JobCommissionRepository = new JobCommissionRepository(_db);
            SkillRepository = new SkillRepository(_db);
            JobEssentialSkillsRepository = new JobEssentialSkillsRepository(_db);
            JobUnnessecarySkillsRepository = new JobUnnessecarySkillsRepository(_db);
            EmployerRepository = new EmployerRepository(_db);
            EmployerAcivityFieldRepository = new EmployerAcivityFieldRepository(_db);
            JobSeekerRepository = new JobSeekerRepository(_db);
            ReminderRepository = new ReminderRepository(_db);
            WorkExperienceRepository = new WorkExperienceRepository(_db);
            WorkExperienceSkillRepository = new WorkExperienceSkillRepository(_db);
            EducationalBackgroundRepository = new EducationalBackgroundRepostory(_db);

            #endregion
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
