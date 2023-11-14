using System.Net.Http.Json;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Services;

public class WaterIntakeService : IWaterIntakeService
{
    private readonly HttpClient _httpClient;

    public WaterIntakeService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<WaterIntakeDto>> GetIntakes()
    {
        var response = await _httpClient.GetAsync("api/WaterIntake");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<WaterIntakeDto>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<WaterIntakeDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<WaterIntakeDto> GetIntakeById(int id)
    {
        var response = await _httpClient.GetAsync($"api/WaterIntake/{id}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(WaterIntakeDto);
            }

            return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<IEnumerable<WaterIntakeDto>> GetUserIntakes(int id)
    {
        var response = await _httpClient.GetAsync($"api/WaterIntake/User/{id}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<WaterIntakeDto>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<WaterIntakeDto>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<WaterIntakeDto> AddIntake(WaterIntakeDto intakeDto)
    {
        var response = await _httpClient.PostAsJsonAsync<WaterIntakeDto>("api/WaterIntake", intakeDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(WaterIntakeDto);
            }

            return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<WaterIntakeDto> EditIntake(WaterIntakeDto intakeDto)
    {
        var response = await _httpClient.PutAsJsonAsync<WaterIntakeDto>("api/WaterIntake", intakeDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(WaterIntakeDto);
            }

            return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<WaterIntakeDto> DeleteIntake(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/WaterIntake/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
            }
            return default(WaterIntakeDto);
        }
        catch (Exception)
        {
            throw;
        }
    }
}