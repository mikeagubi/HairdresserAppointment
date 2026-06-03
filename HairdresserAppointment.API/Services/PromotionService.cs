using HairdresserAppointment.API.Data;
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
        public async Task<string> ValidatePromotionCodeAsync(string code)
        {
            var promotion = await _context.Promotions
                .SingleOrDefaultAsync(p => p.Code == code);
            if(promotion == null)
            {
                return "Ogoiltig rabattkod";
            }

            if(DateTime.Now > promotion.ValidTo)
            {
                return "Rabattkoden har utgått";
            }
            
            if(DateTime.Now < promotion.ValidFrom)
            {
                return "Rabattkoden har inte börjat gälla än";
            }

            return null;
        }



    }
}
