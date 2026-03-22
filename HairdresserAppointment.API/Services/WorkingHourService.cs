using HairdresserAppointment.API.Data;

namespace HairdresserAppointment.API.Services
{
    public class WorkingHourService
    {
        private readonly MyDbContext _context;

        public WorkingHourService(MyDbContext context)
        {
            _context = context;
        }
    }
}
