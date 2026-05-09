using HairdresserAppointmentClient.Dto;

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

       








    }
}
