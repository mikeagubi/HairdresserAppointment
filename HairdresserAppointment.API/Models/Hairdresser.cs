namespace HairdresserAppointment.API.Models
{
    public class Hairdresser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Booking> Bookings { get; set; } = new();
        public List<WorkingHour> WorkingHours { get; set; } = new();

    }
}
