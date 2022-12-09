using GiftShop.Application.Dtos;

namespace GiftShop.Application.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();

        Task<UserDto> GetById(Guid id);

        Task<UserDto> GetByEmail(string email);
    }
}