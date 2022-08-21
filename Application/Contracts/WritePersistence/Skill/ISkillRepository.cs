using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ISkillRepository
    {
        Task<Skill> CreateSkillAsync(Skill skill);
        Task<Skill> GetSkillByIdAsync(short id);
        Task<Skill> GetSkillByTitleAsync(string title);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task<Skill> DeleteSkillByTitleAsync(string title );
        Task<List<Skill>> GetAll();
    }
}
