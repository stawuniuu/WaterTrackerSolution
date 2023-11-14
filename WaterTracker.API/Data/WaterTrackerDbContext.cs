using Microsoft.EntityFrameworkCore;
using WaterConsumptionTracker.Entities;

namespace WaterConsumptionTracker.Data;

public class WaterTrackerDbContext : DbContext
{
    public WaterTrackerDbContext(DbContextOptions<WaterTrackerDbContext> options) : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //user records

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Firstname = "Gladys",
            Surname = "Stevens",
            Email = "gladys.stevens@example.com"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 2,
            Firstname = "Jean",
            Surname = "Garza",
            Email = "jean.garza@example.com"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 3,
            Firstname = "Suzanne ",
            Surname = "Lambert",
            Email = "suzanne.lambert@example.com"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 4,
            Firstname = "James ",
            Surname = "Cooper",
            Email = "james.cooper@example.com"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 5,
            Firstname = "Steven ",
            Surname = "Rice",
            Email = "steven .rice@example.com"
        });

        //water intake records

        modelBuilder.Entity<WaterIntake>().HasData(new WaterIntake
        {
            Id = 1,
            UserId = 1,
            IntakeDate = new DateTime(2023, 5, 1),
            ConsumedWater = 6287
        });

        modelBuilder.Entity<WaterIntake>().HasData(new WaterIntake
        {
            Id = 2,
            UserId = 2,
            IntakeDate = new DateTime(2023, 6, 12),
            ConsumedWater = 4856
        });

        modelBuilder.Entity<WaterIntake>().HasData(new WaterIntake
        {
            Id = 3,
            UserId = 3,
            IntakeDate = new DateTime(2023, 8, 3),
            ConsumedWater = 6832
        });

        modelBuilder.Entity<WaterIntake>().HasData(new WaterIntake
        {
            Id = 4,
            UserId = 4,
            IntakeDate = new DateTime(2023, 6, 19),
            ConsumedWater = 1387
        });

        modelBuilder.Entity<WaterIntake>().HasData(new WaterIntake
        {
            Id = 5,
            UserId = 5,
            IntakeDate = new DateTime(2023, 10, 27),
            ConsumedWater = 8567
        });



    }
    
    public DbSet<User> Users { get; set; }

    public DbSet<WaterIntake> WaterIntakes { get; set;}
}

