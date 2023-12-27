namespace list.Domain.Dto;

public class UserDto
{
    public string UserName { get; set; }
    public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
}