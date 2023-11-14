namespace WaterTracker.Models.Dtos
{
    public record WaterIntakeDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime IntakeDate { get; set; }

        public int ConsumedWater { get; set; }
    }
}
