namespace HairdresserAppointment.API.DTO
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int? HairdresserId { get; set; }
    }
}
