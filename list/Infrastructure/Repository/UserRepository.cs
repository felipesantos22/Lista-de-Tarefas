using list.Domain.Entities;
using list.Domain.Interfaces;
using list.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace list.Infrastructure.Repository;

public class UserRepository : IUser
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> Create(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> Index()
    {
        var tasks = await _dataContext.Users.Include(e => e.Tasks).ToListAsync();
        return tasks;
    }

    public async Task<User?> Show(int id)
    {
        var task = await _dataContext.Users.Include(e => e.Tasks).FirstOrDefaultAsync(c => c.Id == id);
        return task;
    }

    public async Task<User> Update(int id, User user)
    {
        var userUpdate = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        userUpdate!.UserName = user.UserName;
        userUpdate.Password = user.Password;
        await _dataContext.SaveChangesAsync();
        return userUpdate;
    }

    public async Task<User?> Destroy(int id)
    {
        var destroyUser = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Users.Remove(destroyUser!);
        await _dataContext.SaveChangesAsync();
        return destroyUser;
    }
    
    // Function verify user in database
    public async Task<User?> ShowLogin(string name, string password)
    {
        var existingLogin = await _dataContext.Users
            .FirstOrDefaultAsync(e => e.UserName == name && e.Password == password);
        return existingLogin;
    }
}