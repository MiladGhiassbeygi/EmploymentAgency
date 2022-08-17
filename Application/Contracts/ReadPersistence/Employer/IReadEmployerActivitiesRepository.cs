using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;


namespace Application.Contracts.ReadPersistence
{
  
    public interface IReadEmployerActivitiesRepository : IReadBaseRepository<EmployerAcivityField>
    {
        Task<List<EmployerAcivityField>> FilterByTerm(string term);
    }
}
