using Application.Contracts.Persistence;
using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Persistence.WriteRepositories.Common;

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

        public async Task<Skill> GetSkillByIdAsync(short id)
        {
            var skill = await base.TableNoTracking.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return skill;
        }
        public async Task<Skill> DeleteSkillByIdAsync(short id)
        {
            var fetchedSkill = await base.Table.Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

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
            await base.UpdateAsync(skill);
            return skill;
        }
    }
}
