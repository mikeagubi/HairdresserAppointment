namespace HairdresserAppointmentClient.Dto
{
    public class CreateBookingDto
    {
        public int HairdresserId { get; set; }
        public List<int> TreatmentIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
