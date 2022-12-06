using Microsoft.AspNetCore.Identity;

namespace GiftShop.Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; } = default!;
    }
}