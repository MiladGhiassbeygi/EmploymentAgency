using Application.Contracts.ReadPersistence.ReadWorkExperience;
using Domain.ReadModel;
using MongoDB.Driver;
using Persistence.ReadRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ReadRepositories.ReadWorkExperience
{
    public class ReadWorkExperienceRepository : BaseReadRepository<WorkExperience>, IReadWorkExperienceRepository
    {
        public ReadWorkExperienceRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<WorkExperience> GetWorkExperienceByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(x => x.WorkExperienceId == id, cancellationToken);
        }

        public async Task<List<WorkExperience>> GetWorkExperiences()
        {
            return await base.GetAllAsync();
        }
    }
}