using System.ComponentModel.DataAnnotations;

namespace WaterConsumptionTracker.Entities
{
    public record WaterIntake
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime IntakeDate { get; set; }

        [Required]
        public int ConsumedWater { get; set; }
    }
}