using Domain.WriteModel;

namespace Application.Contracts.Persistence
{
    public interface IEmployerAcivityFieldRepository
    {
        Task<EmployerAcivityField> CreateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField);
        Task<EmployerAcivityField> GetEmployerAcivityFieldByIdAsync(int id);
        Task<EmployerAcivityField> GetEmployerAcivityFieldByTitleAsync(string title);
        Task<EmployerAcivityField> UpdateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField);
        Task<EmployerAcivityField> DeleteEmployerAcivityFieldByIdAsync(int id);
        Task<List<EmployerAcivityField>> GetAll();
    }
}
