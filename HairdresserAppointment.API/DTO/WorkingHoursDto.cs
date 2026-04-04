namespace HairdresserAppointment.API.DTO
{
    public class WorkingHourDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
