using list.Domain.Dto;
using Task = list.Domain.Entities.Task;

namespace list.Domain.Interfaces;

public interface ITask
{
    public Task<Task> Create(Task task);
    public Task<List<TaskDto>> Index();
    public Task<Task> Show(int id);
    public Task<Task> Update(int id, Task task);
    public Task<Task> Destroy(int id);
}