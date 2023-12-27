using AutoMapper;
using list.Domain.Dto;
using Task = list.Domain.Entities.Task;

namespace list.Domain.Mapper;

public class EntitieToTaskDto: Profile
{
    public EntitieToTaskDto()
    {
        CreateMap<Task, TaskDto>();
    }
}