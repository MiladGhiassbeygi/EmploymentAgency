using Application.Contracts.ReadPersistence.Common;
using System;
using Domain.ReadModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ReadPersistence.Account
{
    public interface IReadAccountRepository : IReadBaseRepository<User>
    {

    }
}
