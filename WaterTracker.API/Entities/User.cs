using System.ComponentModel.DataAnnotations;

namespace WaterConsumptionTracker.Entities
{
    public record User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }
    }
}