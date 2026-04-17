namespace HairdresserAppointmentClient.ApiServices
{
    public class AuthApiService
    {
        private readonly HttpClient _httpClient;
        public AuthApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("HairdresserAppointmentApi");
        }







    }
}
