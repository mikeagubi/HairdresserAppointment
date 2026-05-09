using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.ApiServices
{
    public class WorkingHourApiService : BaseApiService
    {
        public WorkingHourApiService(IHttpClientFactory factory) 
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {
        }

        
        public async Task<List<WorkingHourDto>> GetWorkingHoursByHairdresserId(string token)
        {
            AddJwtToken(token);

            var response = await _httpClient
                .GetFromJsonAsync<List<WorkingHourDto>>("api/workinghour/workhour-by-id");
            if (response == null)
                return new List<WorkingHourDto>();

            return response;
        }





    }
}
