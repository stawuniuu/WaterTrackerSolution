using WaterTracker.Models.Dtos;

namespace WaterTracker.Web.Services.Contracts
{
    public interface IWaterIntakeService
    {
        Task<IEnumerable<WaterIntakeDto>> GetIntakes();

        Task<WaterIntakeDto> GetIntakeById(int id);

        Task<IEnumerable<WaterIntakeDto>> GetUserIntakes(int id);

        Task<WaterIntakeDto> AddIntake(WaterIntakeDto intakeDto);

        Task<WaterIntakeDto> EditIntake(WaterIntakeDto intakeDto);

        Task<WaterIntakeDto> DeleteIntake(int id);
    }
}