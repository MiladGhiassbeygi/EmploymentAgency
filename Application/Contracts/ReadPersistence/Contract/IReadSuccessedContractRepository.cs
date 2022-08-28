using Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ReadPersistence
{
    public interface IReadSuccessedContractRepository
    {
        Task<List<SuccessedContract>> FilterByTerm(string term, long userId, CancellationToken cancellationToken);
    }
}
