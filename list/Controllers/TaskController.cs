using list.Domain.Dto;
using list.Infrastructure.Repository;
using list.Services.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task = list.Domain.Entities.Task;

namespace list.Controllers;

[ApiController]
[Route("api/task")]
public class TaskController : ControllerBase
{
    private readonly TaskRepository _taskRepository;
    private readonly ValidateFkUser _validateFkUser;

    public TaskController(TaskRepository taskRepository, ValidateFkUser validateFkUser)
    {
        _taskRepository = taskRepository;
        _validateFkUser = validateFkUser;
    }


    /**
    [HttpPost]
    public async Task<ActionResult<Task>> Create([FromBody] Task task)
    {
        var userExists = _validateFkUser.ExistsUserFk(task.UserId);
        if (!userExists)
        {
            return BadRequest(new { message = $"User with ID {task.UserId} not found" });
        }
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest(new { message = "User not authenticated" });
        }
        var newTask = new Task
        {
            Name = task.Name,
            UserId = task.UserId
        };
        var createdTask = await _taskRepository.Create(newTask);
        return Ok(createdTask);
    }*/

    [HttpPost]
    public async Task<ActionResult<Task>> Create([FromBody] Task task)
    {
        var userExists = _validateFkUser.ExistsUserFk(task.UserId);
        if (!userExists)
        {
            return BadRequest(new { message = $"User with ID {task.UserId} not found" });
        }
        var newTask = new Task
        {
            Name = task.Name,
            UserId = task.UserId
        };
        var createdTask = await _taskRepository.Create(newTask);
        return Ok(createdTask);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> Index()
    {
        var tasks = await _taskRepository.Index();
        return Ok(tasks);
    }
}