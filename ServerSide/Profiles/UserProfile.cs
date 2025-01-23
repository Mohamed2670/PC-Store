using AutoMapper;
using ServerSide.Model;

namespace ServerSide.Dto.UserDtos
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserAddDto>();
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserAddDto, User>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}