using AutoMapper;
using list.Domain.Dto;
using list.Domain.Entities;
using list.Infrastructure.Repository;
using list.Services.Token;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace list.Controllers;

[ApiController]
[Route("api/user")]
public class UserController: ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(UserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        var newUser = await _userRepository.Create(user);
        return Ok(newUser);
    }


    [HttpGet]
    public async Task<ActionResult<List<User>>> Index()
    {
        var users = await _userRepository.Index();
        //var usersDto = _mapper.Map<List<UserDto>>(users);
        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> Show(int id)
    {
        var user = await _userRepository.Show(id);
        if (user == null) return NotFound(new { message = "User not found" });
        return Ok(user);
    }


    [HttpPatch("{id}")]
    public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
    {
        var updateUser = await _userRepository.Show(id);
        if (updateUser == null) return NotFound(new { message = "User not found" });
        var doctorUpdate = await _userRepository.Update(id, user);
        return Ok(doctorUpdate);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<User>> Destroy(int id)
    {
        var user = await _userRepository.Show(id);
        if (user == null) return NotFound(new { message = "User not found" });
        var deleteUser = await _userRepository.Destroy(id);
        return Ok(new { message = "User deleted" });
    }
    
    [HttpPost("auth")]
    public async Task<ActionResult<object>> CreateToken([FromBody] User user)
    {
        var authEmployee = await _userRepository.ShowLogin(user.UserName!, user.Password!);
        if (authEmployee == null) return BadRequest("Employee not found in the database");
        var tokenResult = TokenService.GenerateToken(authEmployee);
        return Ok(tokenResult);

    }
}