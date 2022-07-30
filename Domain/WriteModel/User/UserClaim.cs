using Domain.WriteModel.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.WriteModel.User
{
    public class UserClaim:IdentityUserClaim<int>,IEntity
    {
        public User User { get; set; }
    }
  
}
