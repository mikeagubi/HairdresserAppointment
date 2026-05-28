using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class HairdresserService
    {
        private readonly MyDbContext _context;

        public HairdresserService(MyDbContext context)
        {
            _context = context;
        }


        //Hämta alla frisörer
        public async Task<List<HairdresserDto>> GetAllHairdressersAsync()
        {
            return await _context.Hairdressers
                .Where(h => h.IsActive)
                .Select(h => new HairdresserDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    IsActive = h.IsActive,
                    UserEmail = _context.Users
                    .Where(u => u.HairdresserId == h.Id)
                    .Select(u => u.Email)
                    .FirstOrDefault()

                }).ToListAsync();
        }



        //Hämta frisör via Id
        public async Task<HairdresserBookingDto?> GetHairdresserByIdAsync(int id)
        {
            return await _context.Hairdressers
                .Where(h => h.Id == id && h.IsActive)
                .Select(h => new HairdresserBookingDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    IsActive = h.IsActive,
                    WorkingHours = h.WorkingHours

                    .Select(w => new WorkingHoursDto
                    {
                        DayOfWeek = w.DayOfWeek,
                        StartTime = w.StartTime,
                        EndTime = w.EndTime
                    }).ToList(),

                    Bookings = h.Bookings
                    .Where(b => b.IsDeleted == false)
                    
                    .Select(b => new BookingTimeDto
                    {
                        StartTime = b.StartTime,
                        EndTime = b.EndTime
                    }).ToList()

                }).FirstOrDefaultAsync();
        }


        //Soft-delete en frisör
        public async Task<bool> DeleteHairdresserAsync(int id)
        {
            var deletedHairdresser = await _context.Hairdressers.FindAsync(id);
            if (deletedHairdresser == null)
                return false;

            deletedHairdresser.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }


        //Skapa frisör
        public async Task<Hairdresser> CreateHairdresserAsync(CreateHairdresserDto dto)
        {
            var hairdresser = new Hairdresser
            {
                Name = dto.Name,
                IsActive = true,
                WorkingHours = dto.WorkingHours.Select(w => new WorkingHour
                {
                    DayOfWeek = w.DayOfWeek,
                    StartTime = w.StartTime,
                    EndTime = w.EndTime
                }).ToList()
            };
            
            _context.Hairdressers.Add(hairdresser);
            await _context.SaveChangesAsync();

            return hairdresser;
        }










    }
}
