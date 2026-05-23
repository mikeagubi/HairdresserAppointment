using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointmentClient.ApiServices
{
    public class BookingApiService : BaseApiService
    {
        public BookingApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {}



        public async Task<bool> CreateBookingAsync(CreateBookingDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/booking", dto);

            return response.IsSuccessStatusCode;
        }












    }
}
