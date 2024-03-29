﻿using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Contracts.Persistence.JobContract;
using Application.Contracts.ReadPersistence;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Application.Contracts.WritePersistence;
using Application.Contracts.WritePersistence.Reminder;
using MongoDB.Driver;
using Persistence.ReadRepositories;

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
        public IReadJobEssentialRepository ReadJobEssentialRepository { get; }
        public IReadJobCommissionRepository ReadJobCommissionRepository { get; }
        public IReadJobUnnessecarySkillsRepository ReadJobUnnessecarySkillsRepository { get; }
        public IReadJobEssentialSkillsRepository ReadJobEssentialSkillsRepository { get; }
        public IReadReminderRepository ReadReminderRepository { get; }
        public IReadEmployerRepository ReadEmployerRepository { get; }
        public IReadEmployerActivitiesRepository ReadEmployerActivitiesRepository { get; }
        public IReadEmployerCommissionRepository ReadEmployerCommissionRepository { get; }
        public IReadWorkExperienceRepository ReadWorkExperienceRepository { get; }
        public IReadSkillRepository ReadSkillRepository { get; }
        public IReadJobSeekerSkillsRepository ReadJobSeekerSkillsRepository { get; }
        public IReadEducationalBackgroundRepository ReadEducationalBackgroundRepository { get; }
        public IReadSuccessedContractRepository ReadSuccessedContractRepository { get; }

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
        public IJobSeekerSkillsRepository JobSeekerSkillsRepository { get; }
        public IWorkExperienceRepository WorkExperienceRepository { get; }
        public IWorkExperienceSkillRepository WorkExperienceSkillRepository { get; }
        public IEducationalBackgroundRepository EducationalBackgroundRepository { get; }
        public IEmployerCommissionRepository EmployerCommissionRepository { get; }

        #endregion

        public UnitOfWork(ApplicationDbContext db, IMongoDatabase readDb)
        {
            _db = db;
            _readDb = readDb;

            #region ReadRepositories

            ReadCountryRepository = new ReadCountryRepository(_readDb);
            ReadJobSeekerRepository = new ReadJobSeekerRepository(_readDb);
            ReadJobRepository = new ReadJobRepository(_readDb);
            ReadJobEssentialRepository = new ReadJobEssentialRepository(_readDb);
            ReadJobSeekerSkillsRepository = new ReadJobSeekerSkillsRepository(_readDb);
            ReadJobCommissionRepository = new ReadJobCommissionRepository(_readDb);
            ReadEmployerRepository = new ReadEmployerRepository(_readDb);
            ReadEmployerActivitiesRepository = new ReadEmployerActivitiesRepository(_readDb);
            ReadEmployerCommissionRepository = new ReadEmployerCommissionRepository(_readDb);
            ReadReminderRepository = new ReadReminderRepository(_readDb);
            ReadWorkExperienceRepository = new ReadWorkExperienceRepository(_readDb);
            ReadSkillRepository = new ReadSkillRepository(_readDb);
            ReadEducationalBackgroundRepository = new ReadEducationalBackgroundRepository(_readDb);
            ReadSuccessedContractRepository = new ReadSuccessedContractRepository(_readDb);
            ReadJobUnnessecarySkillsRepository = new ReadJobUnnessecarySkillsRepository(_readDb);
            ReadJobEssentialSkillsRepository = new ReadJobEssentialSkillsRepository(_readDb);

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
            JobSeekerSkillsRepository = new JobSeekerSkillsRepository(_db);
            ReminderRepository = new ReminderRepository(_db);
            WorkExperienceRepository = new WorkExperienceRepository(_db);
            WorkExperienceSkillRepository = new WorkExperienceSkillRepository(_db);
            EducationalBackgroundRepository = new EducationalBackgroundRepository(_db);
            EmployerCommissionRepository = new EmployerCommissionRepository(_db);

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
