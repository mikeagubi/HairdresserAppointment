using System.ComponentModel.DataAnnotations;

namespace HairdresserAppointment.API.DTO
{
    public class CreateBookingDto
    {
        public int HairdresserId { get; set; }
        public List<int> TreatmentIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
    }
}
