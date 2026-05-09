using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class WorkingHourService
    {
        private readonly MyDbContext _context;

        public WorkingHourService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkingHoursDto>> GetWorkingHoursByHairdresserIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            return await _context.WorkingHours
                .Where(w => w.HairdresserId == user.HairdresserId)
                .Select(w => new WorkingHoursDto
                {
                    DayOfWeek = w.DayOfWeek,
                    StartTime = w.StartTime,
                    EndTime = w.EndTime
                }).ToListAsync();
  
        }





    }
}
