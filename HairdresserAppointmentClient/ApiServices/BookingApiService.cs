using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointmentClient.ApiServices
{
    public class BookingApiService : BaseApiService
    {
        public BookingApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {}


        //Skapa en bokning
        public async Task<bool> CreateBookingAsync(CreateBookingDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/booking", dto);

            return response.IsSuccessStatusCode;
        }


        //Avboka
        public async Task<IActionResult> CancelBookingAsync()
        {
            return null;
        }










    }
}
