using Microsoft.AspNetCore.Components;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Pages;

public class UsersBase : ComponentBase
{
    [Inject]
    public IUserService UserService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public IEnumerable<UserDto> Users { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Users = await UserService.GetUsers();
    }

    protected async Task AddUser(UserDto userDto)
    {
        var result = await UserService.AddUser(userDto);

        NavigationManager.NavigateTo($"/UserDetails/{result.Id}");
    }
}