using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class PromotionService
    {
        private readonly MyDbContext _context;
        public PromotionService(MyDbContext context)
        {
            _context = context;
        }



        //validerar kampanjkoden
        public async Task<PromotionValidationDto> ValidatePromotionCodeAsync(string code)
        {
            var promotion = await _context.Promotions
                .SingleOrDefaultAsync(p => p.Code == code);
            if(promotion == null)
            {
                return new PromotionValidationDto
                {
                    IsValid = false,
                    Message = "Ogiltig rabattkod"
                };
            }

            if(DateTime.Now > promotion.ValidTo)
            {
                return new PromotionValidationDto
                {
                    IsValid = false,
                    Message = "Rabattkoden har utgått"
                };
            }
            
            if(DateTime.Now < promotion.ValidFrom)
            {
                return new PromotionValidationDto
                {
                    IsValid = false,
                    Message = "Rabattkoden gäller inte än"
                };

            }

            return new PromotionValidationDto
            {
                IsValid = true,
                Message = "Rabattkod tillämpad",
                PromotionId = promotion.Id,
                DiscountPercent = promotion.DiscountPercent,
            };
        }



    }
}
