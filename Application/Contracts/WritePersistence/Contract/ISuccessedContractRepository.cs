using Domain.WriteModel;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface ISuccessedContractRepository
    {
        Task<SuccessedContract> CreateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> GetSuccessedContractByIdAsync(long id);
        Task<SuccessedContract> FindContractByTermAsync(Expression<Func<SuccessedContract, bool>> filter);
        Task<SuccessedContract> UpdateSuccessedContractAsync(SuccessedContract successedContract);
        Task<SuccessedContract> DeleteSuccessedContractByIdAsync(long id);
        Task<List<SuccessedContract>> GetAll();
    }
}
