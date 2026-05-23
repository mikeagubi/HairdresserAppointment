using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class BookingService
    {
        private readonly MyDbContext _context;

        public BookingService(MyDbContext context)
        {
            _context = context;
        }


        public async Task CreateBookingAsync(CreateBookingDto dto)
        {
            var isBooked = await IsTimeBookedAsync(dto.HairdresserId, dto.StartTime, dto.EndTime);
            if (isBooked)
            {
                return;
            }

            var treatments = await _context.Treatments
                .Where(t => dto.TreatmentIds.Contains(t.Id)).ToListAsync();

            var totalPrice = treatments.Sum(t => t.Price);
            var totalDurationInMinutes = treatments.Sum (t => t.DurationInMinutes);

            var booking = new Booking
            {
                HairdresserId = dto.HairdresserId,
                Treatments = treatments,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                CostumerName = dto.CustomerName,
                CostumerEmail = dto.CustomerEmail,
                CostumerPhone = dto.CustomerPhone,
                TotalPrice = totalPrice,
                TotalDurationInMinutes = totalDurationInMinutes

            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

        }

        private async Task<bool> IsTimeBookedAsync(int hairdresserId, DateTime startTime, DateTime endTime)
        {
            var isBooked = await _context.Bookings
                .AnyAsync(b => b.HairdresserId == hairdresserId
                && startTime < b.EndTime
                && endTime > b.StartTime);

            return isBooked;
        }





    }
}
