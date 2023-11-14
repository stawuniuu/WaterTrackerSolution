using Microsoft.AspNetCore.Components;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Pages;

public class IntakeDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    public WaterIntakeDto Intake { get; set; }

    public UserDto User { get; set; }

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
            Intake = await WaterIntakeService.GetIntakeById(Id);
            User = await UserService.GetUserById(Intake.UserId);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task EditIntake(WaterIntakeDto intakeDto)
    {
        var result = await WaterIntakeService.EditIntake(intakeDto);

        NavigationManager.NavigateTo($"/IntakeDetails/{result.Id}");
    }

    protected async Task DeleteIntake(int id)
    {
        await WaterIntakeService.DeleteIntake(id);

        NavigationManager.NavigateTo("/WaterIntakes");
    }
}