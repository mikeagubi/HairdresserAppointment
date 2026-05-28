using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
        }

        //Avbokning
        [HttpPut("cancel-booking")]
        public async Task<ActionResult<string>> CancelBooking(CancelBookingDto dto)
        {
            var success = await _bookingService.CancelBookingAsync(dto);

            return Ok(success);
        }



    }
}
