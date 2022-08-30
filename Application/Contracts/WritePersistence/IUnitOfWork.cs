using Application.Contracts.Persistence.JobContract;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.ReadPersistence;
using Application.Contracts.WritePersistence;
using Application.Contracts.WritePersistence.Reminder;
using Application.Contracts.ReadPersistence.ReadWorkExperience;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {

        #region ReadRepositories

        public IReadCountryRepository ReadCountryRepository { get; }
        public IReadJobSeekerRepository ReadJobSeekerRepository { get; }
        public IReadJobRepository ReadJobRepository { get; }
        public IReadJobEssentialRepository ReadJobEssentialRepository { get; }
        public IReadJobCommissionRepository ReadJobCommissionRepository { get; }
        public IReadJobUnnessecarySkillsRepository ReadJobUnnessecarySkillsRepository { get; }
        public IReadJobEssentialSkillsRepository ReadJobEssentialSkillsRepository { get; }
        public IReadEmployerRepository ReadEmployerRepository { get; }
        public IReadEmployerActivitiesRepository ReadEmployerActivitiesRepository { get; }
        public IReadEmployerCommissionRepository ReadEmployerCommissionRepository { get; }
        public IReadReminderRepository ReadReminderRepository { get; }
        public IReadWorkExperienceRepository ReadWorkExperienceRepository { get; }
        public IReadSkillRepository ReadSkillRepository { get; }
        public IReadJobSeekerSkillsRepository ReadJobSeekerSkillsRepository { get; }
        public IReadEducationalBackgroundRepository ReadEducationalBackgroundRepository { get; }
        public IReadSuccessedContractRepository ReadSuccessedContractRepository { get; }

        #endregion

        #region WriteRepositories

        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IEmployerRepository EmployerRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public IJobRepository JobRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }
        public IJobUnnessecarySkillsRepository JobUnnessecarySkillsRepository { get; }  
        public IJobSeekerRepository JobSeekerRepository { get; }
        public IJobSeekerSkillsRepository JobSeekerSkillsRepository { get; }
        public IReminderRepository ReminderRepository { get; }
        public IWorkExperienceRepository WorkExperienceRepository { get; }
        public IWorkExperienceSkillRepository WorkExperienceSkillRepository { get; }
        public IEducationalBackgroundRepository EducationalBackgroundRepository { get; }
        public IEmployerCommissionRepository EmployerCommissionRepository { get; }

        #endregion

        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
