using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadEducationalBackgroundRepository : IReadBaseRepository<EducationalBackground>
    {
        Task<List<EducationalBackground>> GetEducationalBackgrounds();
        Task<EducationalBackground> GetEducationalBackgroundByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
