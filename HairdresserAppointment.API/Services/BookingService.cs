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

        //skapa en bookning
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
                BookingNumber = GenerateBookingNumber(),
                IsDeleted = false,
                TotalDurationInMinutes = totalDurationInMinutes

            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

        }


        //Avbokning
        public async Task<string> CancelBookingAsync(CancelBookingDto dto)
        {
            var booking = await _context.Bookings
                .Where(b => 
                !b.IsDeleted && b.BookingNumber == dto.BookingNumber && 
                (b.CostumerEmail == dto.Email || b.CostumerPhone == dto.PhoneNumber))
                .SingleOrDefaultAsync();

            if(booking == null)
            {
                return "Kunde ej hitta bokningen, var god och kontrollera dina uppgifter";
            }

            if (CanBeCancelled(booking.StartTime))
            {
                booking.IsDeleted = true;
                await _context.SaveChangesAsync();
                return "Din tid har nu avbokats, Tack och välkommen åter.";
            }

            return "Kan ej avbokas, avbokning måste ske senast 24 timmar innan bokad tid, Välkommen åter.";
        }



        // Kollar om tidsslot är bokad, förhindrar dubbla bokningar
        private async Task<bool> IsTimeBookedAsync(int hairdresserId, DateTime startTime, DateTime endTime)
        {
            var isBooked = await _context.Bookings
                .AnyAsync(b => b.HairdresserId == hairdresserId
                && !b.IsDeleted
                && startTime < b.EndTime
                && endTime > b.StartTime);

            return isBooked;
        }

        //Genererar bokningsnummer
        private string GenerateBookingNumber()
        {
            string month = DateTime.Now.ToString("MMM").ToUpper();
            string numbers = Random.Shared.Next(100000, 999999).ToString();

            return $"{month}-{numbers}";
        }


        //validerar tid kvar för avbokning
        private bool CanBeCancelled(DateTime startTime)
        {
            var timeNow = DateTime.Now;
            var timeLeft = startTime - timeNow;
            var cancelTimeLimit = TimeSpan.FromHours(24);

            if(timeLeft >= cancelTimeLimit)
            {
                return true;
            }

            return false;
        }



    }
}
