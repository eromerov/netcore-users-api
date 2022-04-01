using System;
using AutoMapper;
using UsersApi.Dto;
using UsersApi.Entities;

namespace UsersApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //entities to dto
            CreateMap<User, UserDto>();

            //dto to entities
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
            CreateMap<EditUserDto, User>();
        }
    }
}
