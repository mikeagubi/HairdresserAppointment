namespace HairdresserAppointmentClient.Dto
{
    //för avbokningar
    public class CancelBookingDto
    {
        public string BookingNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
