using System.Net.Http.Json;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var response = await _httpClient.GetAsync("api/User");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<UserDto>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var response = await _httpClient.GetAsync($"api/User/{id}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(UserDto);
            }

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<UserDto> AddUser(UserDto userDto)
    {
        var response = await _httpClient.PostAsJsonAsync<UserDto>("api/User", userDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(UserDto);
            }

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<UserDto> EditUser(UserDto userDto)
    {
        var response = await _httpClient.PutAsJsonAsync<UserDto>("api/User", userDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(UserDto);
            }

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<UserDto> DeleteUser(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/User/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            return default(UserDto);
        }
        catch (Exception)
        {
            throw;
        }
    }
}