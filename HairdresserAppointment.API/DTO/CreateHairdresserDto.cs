namespace HairdresserAppointment.API.DTO
{
    public class CreateHairdresserDto
    {
        public string Name { get; set; } 
        public List<WorkingHourDto> WorkingHours { get; set; } = new();
    }

   
}
