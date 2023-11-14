using Microsoft.AspNetCore.Components;
using WaterTracker.Models.Dtos;
using WaterTracker.Web.Services.Contracts;

namespace WaterTracker.Web.Pages;

public class WaterIntakeBase : ComponentBase
{
    [Inject]
    public IWaterIntakeService WaterIntakeService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public IEnumerable<WaterIntakeDto> Intakes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Intakes = await WaterIntakeService.GetIntakes();
    }

    protected async Task AddIntake(WaterIntakeDto intakeDto)
    {
        var result = await WaterIntakeService.AddIntake(intakeDto);

        NavigationManager.NavigateTo($"/IntakeDetails/{result.Id}");
    }
}