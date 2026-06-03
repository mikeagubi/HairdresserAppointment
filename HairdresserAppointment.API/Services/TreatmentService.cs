using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class TreatmentService
    {
        private readonly MyDbContext _context;

        public TreatmentService(MyDbContext context)

        {
            _context = context;
        }


        public async Task<List<Treatment>> GetAllTreatmentsAsync()
        {
            return await _context.Treatments.ToListAsync();
        }


        public async Task<Treatment> CreateTreatmentAsync(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();

            return treatment;
        }

        public async Task<bool> UpdateTreatmentAsync(Treatment treatment)
        {
            var updateTreatment = await _context.Treatments.FindAsync(treatment.Id);
            if (updateTreatment == null)
                return false;

            updateTreatment.Name = treatment.Name;
            updateTreatment.Price = treatment.Price;
            updateTreatment.DurationInMinutes = treatment.DurationInMinutes;
            updateTreatment.Icon = treatment.Icon;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTreatmentAsync(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
                return false;

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
            return true;
        }












    }
}
