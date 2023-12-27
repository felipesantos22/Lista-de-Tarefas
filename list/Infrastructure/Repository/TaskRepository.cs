using list.Domain.Dto;
using list.Domain.Interfaces;
using list.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = list.Domain.Entities.Task;

namespace list.Infrastructure.Repository;

public class TaskRepository : ITask
{
    private readonly DataContext _dataContext;

    public TaskRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Task> Create(Task task)
    {
        await _dataContext.Tasks.AddAsync(task);
        await _dataContext.SaveChangesAsync();
        return task;
    }

    public async Task<List<TaskDto>> Index()
    {
        var tasks = await _dataContext.Tasks.Select(
            t => new TaskDto()
            {
                Id = t.Id,
                Name = t.Name
            }
            ).ToListAsync();
        return tasks;
    }

    public Task<Task> Show(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Task> Update(int id, Task task)
    {
        throw new NotImplementedException();
    }

    public Task<Task> Destroy(int id)
    {
        throw new NotImplementedException();
    }
}