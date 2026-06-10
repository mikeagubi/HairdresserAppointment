namespace HairdresserAppointmentClient.Dto
{
    //skapa frisör med arbetstider
    public class CreateHairdresserDto
    {
        public string Name { get; set; }
        public List<WorkingHourDto> WorkingHours { get; set; } = new();
    }

    // arbetstider
    public class WorkingHourDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Selected { get; set; }
    }




}
