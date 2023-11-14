using WaterConsumptionTracker.Entities;
using WaterTracker.Models.Dtos;

namespace WaterTracker.API.Extensions;

public static class DtoConversions
{
    public static IEnumerable<UserDto> ConvertToDto(this IEnumerable<User> users)
    {
        return (from user in users
                select new UserDto
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Surname = user.Surname,
                    Email = user.Email
                }).ToList();
    }

    public static UserDto ConvertToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Surname = user.Surname,
            Email = user.Email
        };
    }

    public static User ConvertFromDto(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Firstname = userDto.Firstname,
            Surname = userDto.Surname,
            Email = userDto.Email
        };
    }

    public static WaterIntake ConvertFromDto(this WaterIntakeDto intakeDto)
    {
        return new WaterIntake
        {
            Id = intakeDto.Id,
            UserId = intakeDto.UserId,
            IntakeDate = intakeDto.IntakeDate,
            ConsumedWater = intakeDto.ConsumedWater
        };
    }

    public static IEnumerable<WaterIntakeDto> ConvertToDto(this IEnumerable<WaterIntake> intakes)
    {
        return (from intake in intakes
                select new WaterIntakeDto
                {
                    Id = intake.Id,
                    UserId = intake.UserId,
                    IntakeDate = intake.IntakeDate,
                    ConsumedWater = intake.ConsumedWater
                }).ToList();
    }

    public static WaterIntakeDto ConvertToDto(this WaterIntake intake)
    {
        return new WaterIntakeDto
        {
            Id = intake.Id,
            UserId = intake.UserId,
            IntakeDate = intake.IntakeDate,
            ConsumedWater = intake.ConsumedWater
        };
    }
}