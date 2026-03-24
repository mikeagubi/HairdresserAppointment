using HairdresserAppointment.API.Data;
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

        public async Task<List<Hairdresser>> GetAllHairdressersAsync()
        {
            return await _context.Hairdressers.ToListAsync();
        }

        public async Task<Hairdresser> GetHairdresserByIdAsync(int id)
        {
            return await _context.Hairdressers.FindAsync(id);
        }

        public async Task<Hairdresser> CreateHairdresserAsync(Hairdresser hairdresser)
        {
            _context.Hairdressers.Add(hairdresser);
            _context.SaveChanges();

            return hairdresser;
        }

        public async Task<bool> UpdateHairdresserAsync(int id, Hairdresser hairdresser)
        {
            var updateHairdresser = _context.Hairdressers.Find(id);
            if(updateHairdresser == null)
                return false;

            updateHairdresser.Name = hairdresser.Name;
            updateHairdresser.DayOff = hairdresser.DayOff;
            updateHairdresser.IsActive = hairdresser.IsActive;
            updateHairdresser.WorkingHours = hairdresser.WorkingHours;

            _context.SaveChanges();
            return true;
        }


        public async Task<bool> SoftDeleteHairdresser(int id)
        {
            var deletedHairdresser = await _context.Hairdressers.FindAsync(id);

            deletedHairdresser.IsActive
        }













    }
}
