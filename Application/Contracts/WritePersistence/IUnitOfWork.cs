using Application.Contracts.Persistence.JobContract;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;
using Application.Contracts.ReadPersistence;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IReadCountryRepository ReadCountryRepository { get; }
        public IReadJobSeekerRepository ReadJobSeekerRepository { get; }
        public IReadJobRepository ReadJobRepository { get; }
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public IJobRepository JobRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }
        public IJobSeekerRepository JobSeekerRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
