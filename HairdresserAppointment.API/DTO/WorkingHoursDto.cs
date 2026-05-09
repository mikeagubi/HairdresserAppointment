namespace HairdresserAppointment.API.DTO
{
    public class WorkingHoursDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
