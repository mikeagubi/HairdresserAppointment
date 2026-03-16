namespace HairdresserAppointment.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public string CostumerPhone{ get; set; }
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }


    }
}
