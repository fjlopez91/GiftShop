using GiftShop.Domain.Entities.Identity;

namespace GiftShop.Application.Utils
{
    public interface IJwtUtils
    {
        public string GetJwtToken(User user);

        public string ValidateToken(string token);
    }
}