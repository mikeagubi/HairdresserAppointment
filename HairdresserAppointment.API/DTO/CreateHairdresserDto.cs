namespace HairdresserAppointment.API.DTO
{
    public class CreateHairdresserDto
    {
        public string Name { get; set; } 
        public List<WorkingHoursDto> WorkingHours { get; set; } = new();
    }

   
}
