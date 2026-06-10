using System.ComponentModel.DataAnnotations;

namespace HairdresserAppointmentClient.Dto
{
    //Hämta frisör bokningar
    public class BookingDto
    {
        public Guid Id { get; set; }
        public int HairdresserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalDurationInMinutes { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public string CostumerPhone { get; set; }
        public int? PromotionId { get; set; }
        public string BookingNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string HairdresserName { get; set; }
        public List<string> Treatments { get; set; }
    }
}
