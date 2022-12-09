using AutoMapper;
using GiftShop.Application.Dtos;
using GiftShop.Domain.Entities.Identity;

namespace GiftShop.Application.Mappings
{
    public sealed class UsersMapping : Profile
    {
        public UsersMapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.IsEnabled, e => e.MapFrom(x => x.Status == Domain.Enums.EnabledStatus.Enabled));
        }
    }
}