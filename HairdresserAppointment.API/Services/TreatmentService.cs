using HairdresserAppointment.API.Data;

namespace HairdresserAppointment.API.Services
{
    public class TreatmentService
    {
        private readonly MyDbContext _context;

        public TreatmentService(MyDbContext context)
        {
            _context = context;
        }
    }
}
