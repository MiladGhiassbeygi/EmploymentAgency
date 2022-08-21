using Application.Contracts.Persistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.WriteRepositories
{
    internal class SkillRepository : BaseAsyncRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            var newSkill = skill;
            await base.AddAsync(newSkill);
            return newSkill;
        }

        public async Task<Skill> DeleteSkillByTitleAsync(string title)
        {
            var fetchedSkill = await base.Table.Where(t => t.Title.Equals(title)).FirstOrDefaultAsync();

            await base.DeleteAsync(fetchedSkill);
            return fetchedSkill;
        }

        public async Task<List<Skill>> GetAll()
        {
            return await base.TableNoTracking.ToListAsync();
        }

        public async Task<Skill> GetSkillByTitleAsync(string title)
        {
            var skill = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return skill;
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            var fetchedskill = await base.Table.Where(t => t.Title.Equals(skill.Title)).FirstOrDefaultAsync();

            if (fetchedskill == null) return null;
            await base.UpdateAsync(fetchedskill);
            return fetchedskill;
        }
    }
}
