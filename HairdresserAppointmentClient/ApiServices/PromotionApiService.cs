using Azure;

namespace HairdresserAppointmentClient.ApiServices
{
    public class PromotionApiService : BaseApiService
    {
        public PromotionApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        { }


        public async Task<string> ValidatePromotionCodeAsync(string code)
        {
            return await _httpClient.GetStringAsync($"api/promotion/validate-code/{code}");
        }



    }
}
