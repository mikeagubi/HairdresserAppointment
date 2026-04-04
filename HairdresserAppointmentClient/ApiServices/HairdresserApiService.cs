using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.ApiServices
{
    public class HairdresserApiService
    {
        private readonly HttpClient _httpClient;

        public HairdresserApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("HairdresserAppointmentApi");
        }


        public async Task<bool> CreateWithTimeAsync(CreateHairdresserDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/hairdresser/create-with-time", dto);

            return response.IsSuccessStatusCode;
        }

    }
}
