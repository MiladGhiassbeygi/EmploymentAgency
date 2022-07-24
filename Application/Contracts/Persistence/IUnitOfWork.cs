using Application.Contracts.Persistence.Area;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IEmployerAcivityFieldRepository EmployerAcivityFieldRepository { get; }
        public ISuccessedContractRepository SuccessedContractRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
