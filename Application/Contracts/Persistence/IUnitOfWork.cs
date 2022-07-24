namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IJobRepository JobRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
