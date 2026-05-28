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
        public async Task<string> CancelBookingAsync(CancelBookingDto dto, string token)
        {
            AddJwtToken(token);

            var response = await _httpClient.PutAsJsonAsync("api/booking/cancel-booking", dto);

            var responseText = await response.Content.ReadAsStringAsync();

            return responseText;
        }










    }
}
