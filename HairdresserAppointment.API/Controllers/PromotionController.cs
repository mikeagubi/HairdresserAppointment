using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionService;
        public PromotionController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }


        //validerar kampanjkoden
        [HttpGet("validate-code/{code}")]
        public async Task<string> ValidatePromotion(string code)
        {
            var response = await _promotionService.ValidatePromotionCodeAsync(code);

            return response;
        }


    }
}
