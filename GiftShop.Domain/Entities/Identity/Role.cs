using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; } = default!;
        public virtual ICollection<RoleClaim> RoleClaims { get; set; } = default!;
    }
}