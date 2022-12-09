using GiftShop.Domain.Entities.Identity;

namespace GiftShop.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public List<UserRole> UserRoles { get; set; } = default!;
        public bool IsEnabled { get; set; }
    }
}