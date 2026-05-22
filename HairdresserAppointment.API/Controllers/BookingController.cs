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


        [HttpPost]
        public async Task CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
        }




    }
}
