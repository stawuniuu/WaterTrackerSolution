using WaterConsumptionTracker.Entities;

namespace WaterTracker.API.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);

        Task<User> EditUser(User user);

        Task<User> DeleteUser(int id);
    }
}