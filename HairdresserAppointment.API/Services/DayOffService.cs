using HairdresserAppointment.API.Data;

namespace HairdresserAppointment.API.Services
{
    public class DayOffService
    {
        private readonly MyDbContext _context;

        public DayOffService(MyDbContext context)
        {
            _context = context;
        }



    }
}
