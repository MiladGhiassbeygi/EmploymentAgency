using Domain.WriteModel;

namespace Application.Contracts.Persistence
{
    public interface ISuccessedContractRepository
    {
        Task<SuccessedContract> CreateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> GetSuccessedContractByIdAsync(long id);
        Task<SuccessedContract> FindContractByTermAsync(SuccessedContract successedContract);
        Task<SuccessedContract> UpdateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> DeleteSuccessedContractByIdAsync(long id);
        Task<List<SuccessedContract>> GetAll();
    }
}
