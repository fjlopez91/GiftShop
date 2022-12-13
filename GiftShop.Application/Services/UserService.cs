using AutoMapper;
using GiftShop.Application.Dtos;
using GiftShop.Domain.Entities.Identity;
using GiftShop.Persistence;

namespace GiftShop.Application.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var entities = await _unitOfWork.UserRepository.GetAll();

            return _mapper.Map<List<UserDto>>(entities);
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await GetUser(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Email == email);
            if (user == null) throw new KeyNotFoundException(AppResource.UserNotFound);
            return _mapper.Map<UserDto>(user);
        }        

        private Task<User> GetUser(Guid id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            if (user == null) throw new KeyNotFoundException(AppResource.UserNotFound);
            return user;
        }
    }
}