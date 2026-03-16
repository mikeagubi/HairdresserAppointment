namespace HairdresserAppointment.API.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool OneTimeUsage { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
