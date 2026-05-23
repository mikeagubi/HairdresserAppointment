namespace HairdresserAppointment.API.DTO
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public decimal Price { get; set; }
        public string? Icon { get; set; }
    }
}
