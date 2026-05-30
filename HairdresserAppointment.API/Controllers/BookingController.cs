using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HairdresserAppointment.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //Skapa en bokning
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            var bookingNumber =  await _bookingService.CreateBookingAsync(dto);

            return Ok(bookingNumber);
        }

        //Avbokning
        [HttpPut("cancel-booking")]
        public async Task<ActionResult<string>> CancelBooking(CancelBookingDto dto)
        {
            var response = await _bookingService.CancelBookingAsync(dto);

            return Ok(response);
        }

        //hämta frisör bokningar
        [Authorize(Roles = "Hairdresser")]
        [HttpGet("get-hairdresser-bookings")]
        public async Task<ActionResult<List<BookingDto>>> GetHairdresserBookings()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _bookingService.GetHairdresserBookingAsync(userId);


            return Ok(response);
        }




    }
}
