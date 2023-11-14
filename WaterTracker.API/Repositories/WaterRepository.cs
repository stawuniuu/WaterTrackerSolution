using Microsoft.EntityFrameworkCore;
using WaterConsumptionTracker.Data;
using WaterConsumptionTracker.Entities;
using WaterTracker.API.Repositories.Contracts;

namespace WaterTracker.API.Repositories;

public class WaterRepository : IWaterRepository
{
    private readonly WaterTrackerDbContext _waterTrackerDbContext;

    public WaterRepository(WaterTrackerDbContext waterTrackerDbContext)
    {
        _waterTrackerDbContext = waterTrackerDbContext;
    }

    public async Task<IEnumerable<WaterIntake>> GetIntakes()
    {
        return await _waterTrackerDbContext.WaterIntakes.ToListAsync();
    }

    public async Task<WaterIntake> GetIntakeById(int id)
    {
        return await _waterTrackerDbContext.WaterIntakes.FindAsync(id);
    }

    public async Task<IEnumerable<WaterIntake>> GetUserIntakes(int userId)
    {
        var intakes = await GetIntakes();

        return intakes.Where(x => x.UserId == userId);
    }

    public async Task<WaterIntake> AddIntake(WaterIntake intake)
    {
        if (intake != null)
        {
            var result = await _waterTrackerDbContext.WaterIntakes.AddAsync(intake);

            await _waterTrackerDbContext.SaveChangesAsync();

            return result.Entity;
        }

        return null;
    }

    public async Task<WaterIntake> EditIntake(WaterIntake intake)
    {
        var selectedIntake = await _waterTrackerDbContext.WaterIntakes.FindAsync(intake.Id);

        if (selectedIntake != null)
        {
            selectedIntake.UserId = intake.UserId;
            selectedIntake.IntakeDate = intake.IntakeDate;
            selectedIntake.ConsumedWater = intake.ConsumedWater;

            await _waterTrackerDbContext.SaveChangesAsync();

            return selectedIntake;
        }

        return null;
    }

    public async Task<WaterIntake> DeleteIntake(int id)
    {
        var intake = await _waterTrackerDbContext.WaterIntakes.FindAsync(id);

        if (intake != null)
        {
            _waterTrackerDbContext.WaterIntakes.Remove(intake);
            await _waterTrackerDbContext.SaveChangesAsync();
        }

        return intake;
    }
}