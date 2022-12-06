using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; } = default!;
    }
}