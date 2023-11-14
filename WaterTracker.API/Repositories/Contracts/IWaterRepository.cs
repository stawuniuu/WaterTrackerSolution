using WaterConsumptionTracker.Entities;

namespace WaterTracker.API.Repositories.Contracts
{
    public interface IWaterRepository
    {
        Task<IEnumerable<WaterIntake>> GetIntakes();

        Task<WaterIntake> GetIntakeById(int id);

        Task<IEnumerable<WaterIntake>> GetUserIntakes(int userId);

        Task<WaterIntake> AddIntake(WaterIntake intake);

        Task<WaterIntake> EditIntake(WaterIntake intake);

        Task<WaterIntake> DeleteIntake(int id);
    }
}