namespace HairdresserAppointmentClient.Dto
{
    public class PromotionValidationDto
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public int PromotionId { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
