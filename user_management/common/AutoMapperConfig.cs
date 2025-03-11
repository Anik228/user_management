using AutoMapper;

using user_management.module.user.model;

namespace user_management.common
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();
          

        }
    }
}
