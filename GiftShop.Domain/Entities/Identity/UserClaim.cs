using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public virtual User User { get; set; } = default!;
    }
}