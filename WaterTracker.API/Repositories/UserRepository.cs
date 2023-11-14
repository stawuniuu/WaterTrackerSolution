using Microsoft.EntityFrameworkCore;
using WaterConsumptionTracker.Data;
using WaterConsumptionTracker.Entities;
using WaterTracker.API.Repositories.Contracts;

namespace WaterTracker.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WaterTrackerDbContext _waterTrackerDbContext;

    public UserRepository(WaterTrackerDbContext waterTrackerDbContext)
    {
        _waterTrackerDbContext = waterTrackerDbContext;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _waterTrackerDbContext.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _waterTrackerDbContext.Users.FindAsync(id);
    }

    public async Task<User> AddUser(User user)
    {
        if (user != null)
        {
            var result = await _waterTrackerDbContext.Users.AddAsync(user);

            await _waterTrackerDbContext.SaveChangesAsync();

            return result.Entity;
        }

        return null;
    }

    public async Task<User> EditUser(User user)
    {
        var selectedUser = await _waterTrackerDbContext.Users.FindAsync(user.Id);

        if (selectedUser != null)
        {
            selectedUser.Firstname = user.Firstname;
            selectedUser.Surname = user.Surname;
            selectedUser.Email = user.Email;

            await _waterTrackerDbContext.SaveChangesAsync();

            return selectedUser;
        }

        return null;
    }

    public async Task<User> DeleteUser(int id)
    {
        var user = await _waterTrackerDbContext.Users.FindAsync(id);

        if (user != null)
        {
            _waterTrackerDbContext.Users.Remove(user);
            await _waterTrackerDbContext.SaveChangesAsync();
        }

        return user;
    }
}