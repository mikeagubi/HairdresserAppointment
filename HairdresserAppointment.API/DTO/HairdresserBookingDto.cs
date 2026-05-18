using HairdresserAppointment.API.Models;

namespace HairdresserAppointment.API.DTO
{
    public class HairdresserBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<WorkingHoursDto> WorkingHours { get; set; }
        public List<BookingTimeDto> Bookings { get; set; }
    }
}
