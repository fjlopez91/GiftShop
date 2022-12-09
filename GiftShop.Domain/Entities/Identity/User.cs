using GiftShop.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public EnabledStatus Status { get; set; } = default!;
        public DateTime DateCreated { get; set; } = default!;
        public virtual ICollection<UserClaim> Claims { get; set; } = default!;
        public virtual ICollection<UserLogin> Logins { get; set; } = default!;
        public virtual ICollection<UserToken> Tokens { get; set; } = default!;
        public virtual ICollection<UserRole> UserRoles { get; set; } = default!;
    }
}