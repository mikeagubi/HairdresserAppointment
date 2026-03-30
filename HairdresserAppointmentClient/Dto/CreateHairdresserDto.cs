namespace HairdresserAppointmentClient.Dto
{
    public class CreateHairdresserDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<WorkingHourDto> WorkingHours { get; set; } = new();
    }

    public class WorkingHourDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Selected { get; set; }
    }




}
