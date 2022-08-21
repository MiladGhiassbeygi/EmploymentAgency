using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;

namespace Application.Contracts.ReadPersistence
{
   
    public interface IReadSkillRepository : IReadBaseRepository<Skill>
    {
        Task<bool> AnyListAsync(short[] skillIds);
    }
}
