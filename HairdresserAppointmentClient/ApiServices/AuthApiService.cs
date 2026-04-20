using HairdresserAppointmentClient.Dto;



namespace HairdresserAppointmentClient.ApiServices
{
    public class AuthApiService
    {
        private readonly HttpClient _httpClient;
        public AuthApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("HairdresserAppointmentApi");
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", dto);
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            return result.Token;
        }







    }
}
