namespace HairdresserAppointmentClient.Dto
{
    //Innehåller bokningarnas start o sluttider, 
    //används för att kolla om en ny tid är ledig
    public class BookingTimeDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
