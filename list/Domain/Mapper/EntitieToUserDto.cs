using AutoMapper;
using list.Domain.Dto;
using list.Domain.Entities;

namespace list.Domain.Mapper;

public class EntitieToUserDto: Profile
{
    public EntitieToUserDto()
    {
        CreateMap<User, UserDto>();
    }
    
    
}