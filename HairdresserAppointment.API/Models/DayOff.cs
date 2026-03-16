namespace HairdresserAppointment.API.Models
{
    public class DayOff
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public DateTime Date { get; set; }
        public DayOffReason Reason { get; set; }
    }
}
