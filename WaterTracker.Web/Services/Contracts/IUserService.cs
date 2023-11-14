using WaterTracker.Models.Dtos;

namespace WaterTracker.Web.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int id);

        Task<UserDto> AddUser(UserDto userDto);

        Task<UserDto> DeleteUser(int id);

        Task<UserDto> EditUser(UserDto userDto);
    }
}