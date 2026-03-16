namespace HairdresserAppointment.API.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public decimal Price { get; set; }
    }
}
