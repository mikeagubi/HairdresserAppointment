using HairdresserAppointmentClient.Dto;
using System.Reflection.Metadata.Ecma335;

namespace HairdresserAppointmentClient.ApiServices
{
    public class TreatmentApiService : BaseApiService
    {
        public TreatmentApiService(IHttpClientFactory factory)
           : base(factory.CreateClient("HairdresserAppointmentApi"))
        {
        }


        public async Task<List<TreatmentDto>> GetAllTreatments()
        {

            var response = await _httpClient.GetFromJsonAsync<List<TreatmentDto>>("api/treatment");
            if(response == null)
                return new List<TreatmentDto>();

            return response;
        }

        public async Task<bool> CreateTreatmentAsync(TreatmentDto dto, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.PostAsJsonAsync("api/treatment", dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTreatmentAsync(TreatmentDto dto, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.PutAsJsonAsync("api/treatment", dto);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteTreatmentAsync(int id, string token)
        {
            AddJwtToken(token);
            var response = await _httpClient.DeleteAsync($"api/treatment/{id}" );

            return response.IsSuccessStatusCode;
        }











    }
}
