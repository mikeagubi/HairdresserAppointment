using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.ApiServices
{
    public class HairdresserApiService : BaseApiService
    {

        public HairdresserApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {
        }


        public async Task<bool> CreateWithTimeAsync(CreateHairdresserDto dto, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.PostAsJsonAsync("api/hairdresser/create-with-time", dto);

            return response.IsSuccessStatusCode;
        }


        public async Task<List<HairdresserDto>> GetHairdressersAsync(string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.GetFromJsonAsync<List<HairdresserDto>>("api/hairdresser");

            if (response == null)
                return new List<HairdresserDto>();

            return response;
        }




    }
}
