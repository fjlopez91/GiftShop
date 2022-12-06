using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; } = default!;
    }
}