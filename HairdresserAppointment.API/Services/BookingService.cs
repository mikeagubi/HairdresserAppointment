using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Services
{
    public class BookingService
    {
        private readonly MyDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingService(MyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //skapa en bookning
        public async Task<string> CreateBookingAsync(CreateBookingDto dto)
        {
            var isBooked = await IsTimeBookedAsync(dto.HairdresserId, dto.StartTime, dto.EndTime);
            if (isBooked)
            {
                return null;
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

            return booking.BookingNumber;
        }

        //Genererar bokningsnummer
        private string GenerateBookingNumber()
        {
            string month = DateTime.Now.ToString("MMM").ToUpper();
            string numbers = Random.Shared.Next(100000, 999999).ToString();

            return $"{month}-{numbers}";
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



        //Avbokning
        public async Task<string> CancelBookingAsync(CancelBookingDto dto)
        {
            var booking = await _context.Bookings
                .Where(b => 
                !b.IsDeleted && b.BookingNumber == dto.BookingNumber && 
                (b.CostumerEmail == dto.Email || b.CostumerPhone == dto.PhoneNumber))
                .SingleOrDefaultAsync();
            
            var isAdminOrHairdresser = _httpContextAccessor.HttpContext.User.IsInRole("Admin") ||
                _httpContextAccessor.HttpContext.User.IsInRole("Hairdresser");

            if (booking == null)
            {
                return "Kunde ej hitta bokningen, var god och kontrollera dina uppgifter";
            }

            if (CanBeCancelled(booking.StartTime) || isAdminOrHairdresser)
            {
                booking.IsDeleted = true;
                await _context.SaveChangesAsync();
                return "Din tid har nu avbokats, Tack och välkommen åter.";
            }

            return $"Kan ej avbokas, avbokning måste ske senast 24 timmar innan bokad tid.\n Välkommen åter.";
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



        //Hämta frisör bokningar
        public async Task<List<BookingDto>> GetHairdresserBookingAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            return await _context.Bookings
                .Where(b => b.HairdresserId == 42 && !b.IsDeleted)
                .Include(b => b.Hairdresser)
                .Include(b => b.Treatments)
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    HairdresserId = b.HairdresserId,
                    StartTime = b.StartTime,
                    EndTime = b.EndTime,
                    TotalDurationInMinutes = b.TotalDurationInMinutes,
                    TotalPrice = b.TotalPrice,
                    CostumerName = b.CostumerName,
                    CostumerEmail = b.CostumerEmail,
                    CostumerPhone = b.CostumerPhone,
                    BookingNumber = b.BookingNumber,
                    HairdresserName = b.Hairdresser.Name,
                    PromotionId = b.PromotionId,
                    IsDeleted = b.IsDeleted,
                    Treatments = b.Treatments
                    .Select(t => t.Name)
                    .ToList()
                }).ToListAsync();
        }
        




       



    }
}
