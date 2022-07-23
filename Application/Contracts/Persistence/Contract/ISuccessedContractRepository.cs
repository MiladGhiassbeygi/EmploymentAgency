

using Domain.Entities;

namespace Application.Contracts.Persistence.Contract
{
    public interface ISuccessedContractRepository
    {
        Task<SuccessedContract> CreateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> GetSuccessedContractByIdAsync(int id);
        Task<SuccessedContract> FindContractByTermAsync(SuccessedContract successedContract);
        Task<SuccessedContract> UpdateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> DeleteSuccessedContractByIdAsync(int id);
        Task<List<SuccessedContract>> GetAll();
    }
}
