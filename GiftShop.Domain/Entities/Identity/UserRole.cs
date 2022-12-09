using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; } = default!;
        public virtual Role Role { get; set; } = default!;
    }
}