using HairdresserAppointmentClient.Dto;



namespace HairdresserAppointmentClient.ApiServices
{
    public class AuthApiService : BaseApiService
    {

        public AuthApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        {
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", dto);
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            return result.Token;
        }

        public async Task<bool> CreateUserAsync(CreateUserDto dto, string token)
        {
            AddJwtToken(token);

            var response = await _httpClient.PostAsJsonAsync("api/Auth/create-user", dto);

            return response.IsSuccessStatusCode;
        }







    }
}
