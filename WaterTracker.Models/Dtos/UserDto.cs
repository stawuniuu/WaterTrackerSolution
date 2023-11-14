namespace WaterTracker.Models.Dtos
{
    public record UserDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
