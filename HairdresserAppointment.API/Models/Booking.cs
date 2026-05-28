using System.ComponentModel.DataAnnotations;

namespace HairdresserAppointment.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalDurationInMinutes { get; set; }
        [Required]
        public string CostumerName { get; set; }
        [Required]
        public string CostumerEmail { get; set; }
        [Required]
        public string CostumerPhone{ get; set; }
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
        public string BookingNumber { get; set; }
        public bool IsDeleted { get; set; }
        public List<Treatment> Treatments { get; set; } = new();

    }
}
