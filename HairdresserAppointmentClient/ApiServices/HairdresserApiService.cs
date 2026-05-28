using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.ApiServices
{
    public class HairdresserApiService : BaseApiService
    {

        public HairdresserApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {
        }


        //Skapa Frisör
        public async Task<bool> CreateWithTimeAsync(CreateHairdresserDto dto, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.PostAsJsonAsync("api/hairdresser/create-with-time", dto);

            return response.IsSuccessStatusCode;
        }


        //Hämta alla frisörer
        public async Task<List<HairdresserDto>> GetHairdressersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<HairdresserDto>>("api/hairdresser");
                return response ?? new List<HairdresserDto>();
            }
            catch
            {
                return new List<HairdresserDto>();
            }
        }


        //Hämta frisör via Id
        public async Task<HairdresserBookingDto?> GetHairdresserByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<HairdresserBookingDto>($"api/hairdresser/{id}");
            }
            catch
            {
                return null;
            }
        }

        
        //soft-delete Frisör
        public async Task<bool> DeleteHairdresserAsync(int id, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.PutAsync($"api/hairdresser/delete/{id}", null);

            return response.IsSuccessStatusCode;
        }




    }
}
