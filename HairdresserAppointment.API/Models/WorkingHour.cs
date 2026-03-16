namespace HairdresserAppointment.API.Models
{
    public class WorkingHour
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
