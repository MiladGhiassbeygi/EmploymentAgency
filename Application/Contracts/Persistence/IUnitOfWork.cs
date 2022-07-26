using Application.Contracts.Persistence.JobContract;
using Application.Contracts.Persistence.Area;
using Application.Contracts.ReadPersistence.Area;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IReadCountryRepository ReadCountryRepository { get; }
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobCommissionRepository JobCommissionRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IJobEssentialSkillsRepository JobEssentialSkillsRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
