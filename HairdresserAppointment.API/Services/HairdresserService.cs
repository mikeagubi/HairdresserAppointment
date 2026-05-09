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

        public async Task<List<HairdresserDto>> GetAllHairdressersAsync()
        {
            return await _context.Hairdressers
                .Where(h => h.IsActive)
                .Select(h => new HairdresserDto
                {
                    Id = h.Id,
                    Name = h.Name,

                    UserEmail = _context.Users
                    .Where(u => u.HairdresserId == h.Id)
                    .Select(u => u.Email)
                    .FirstOrDefault()
                }).ToListAsync();
        }

        public async Task<Hairdresser> GetHairdresserByIdAsync(int id)
        {
            return await _context.Hairdressers.FindAsync(id);
        }


        public async Task<bool> UpdateHairdresserAsync(int id, Hairdresser hairdresser)
        {
            var updateHairdresser = _context.Hairdressers.Find(id);
            if(updateHairdresser == null)
                return false;

            updateHairdresser.Name = hairdresser.Name;
            updateHairdresser.IsActive = hairdresser.IsActive;
            updateHairdresser.WorkingHours = hairdresser.WorkingHours;

            _context.SaveChanges();
            return true;
        }


        public async Task<bool> SoftDeleteHairdresser(int id)
        {
            var deletedHairdresser = await _context.Hairdressers.FindAsync(id);
            if (deletedHairdresser == null)
                return false;

            deletedHairdresser.IsActive = false;
            _context.SaveChanges();

            return true;
        }

        public async Task<Hairdresser> CreateStackAsync(CreateHairdresserDto dto)
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
