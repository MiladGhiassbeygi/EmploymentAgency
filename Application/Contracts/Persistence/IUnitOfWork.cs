using Application.Contracts.Persistence.JobContract;

using Application.Contracts.Persistence.Area;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
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
