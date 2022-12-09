namespace GiftShop.Application.Dtos
{
    public class UserForAuthenticationDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}