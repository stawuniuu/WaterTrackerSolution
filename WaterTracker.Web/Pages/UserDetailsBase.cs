using Microsoft.AspNetCore.Components;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Pages;

public class UserDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    public UserDto User { get; set; }

    public IEnumerable<WaterIntakeDto> Intakes { get; set; }

    public string ErrorMessage { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    private IUserService UserService { get; set; }

    [Inject]
    private IWaterIntakeService WaterIntakeService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            User = await UserService.GetUserById(Id);
            Intakes = await WaterIntakeService.GetUserIntakes(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task EditUser(UserDto userDto)
    {
        var result = await UserService.EditUser(userDto);

        NavigationManager.NavigateTo($"UserDetails/{result.Id}");
    }

    protected async Task DeleteUser(int id)
    {
        await UserService.DeleteUser(id);

        NavigationManager.NavigateTo("/");
    }
}