using Azure;

namespace HairdresserAppointmentClient.ApiServices
{
    public class PromotionApiService : BaseApiService
    {
        public PromotionApiService(IHttpClientFactory factory)
            : base(factory.CreateClient("HairdresserAppointmentApi"))
        { }

    }
}
