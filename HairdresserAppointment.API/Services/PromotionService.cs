using HairdresserAppointment.API.Data;

namespace HairdresserAppointment.API.Services
{
    public class PromotionService
    {
        private readonly MyDbContext _context;

        public PromotionService(MyDbContext context)
        {
            _context = context;
        }
    }
}
