namespace HairdresserAppointmentClient.Dto
{
    public class HairdresserBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<WorkingHourDto> WorkingHours { get; set; }
        public List<BookingTimeDto> Bookings { get; set; }
    }
}
