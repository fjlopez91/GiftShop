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
            var entities = _unitOfWork.GetRepository<User>().GetAllAsQueryable().ToList();

            return await Task.FromResult(_mapper.Map<List<UserDto>>(entities));
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = GetUser(id);
            return await Task.FromResult(_mapper.Map<UserDto>(user));
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = _unitOfWork.GetRepository<User>().Find(x => x.Email == email).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");
            return await Task.FromResult(_mapper.Map<UserDto>(user));
        }

        private User GetUser(Guid id)
        {
            var user = _unitOfWork.GetRepository<User>().FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}