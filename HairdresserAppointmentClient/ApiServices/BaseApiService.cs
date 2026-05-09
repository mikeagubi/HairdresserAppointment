using System.Net.Http.Headers;

namespace HairdresserAppointmentClient.ApiServices
{
    public class BaseApiService
    {
        protected readonly HttpClient _httpClient;
        public BaseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected void AddJwtToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }



    }
}
