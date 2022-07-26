using Domain.WriteModel.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.WriteModel.User
{
    public class UserRole : IdentityUserRole<int>,IEntity
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedUserRoleDate { get; set; }

    }
}
