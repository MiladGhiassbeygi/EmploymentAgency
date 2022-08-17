using Domain.WriteModel;

namespace Application.Contracts.WritePersistence
{
    public interface IEmployerAcivityFieldRepository
    {
        Task<EmployerAcivityField> CreateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField);
        Task<EmployerAcivityField> GetEmployerAcivityFieldByIdAsync(byte id);
        Task<EmployerAcivityField> GetEmployerAcivityFieldByTitleAsync(string title);
        Task<EmployerAcivityField> UpdateEmployerAcivityFieldAsync(EmployerAcivityField employerAcivityField);
        Task<EmployerAcivityField> DeleteEmployerAcivityFieldByIdAsync(int id);
        Task<List<EmployerAcivityField>> GetAll();
    }
}
