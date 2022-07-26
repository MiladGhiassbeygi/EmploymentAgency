using Domain.WriteModel.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.WriteModel.User
{
    public class RoleClaim:IdentityRoleClaim<int>,IEntity
    {
        public RoleClaim()
        {
            CreatedClaim=DateTime.Now;
        }

        public DateTime CreatedClaim { get; set; }
        public Role Role { get; set; }

    }
  
}
