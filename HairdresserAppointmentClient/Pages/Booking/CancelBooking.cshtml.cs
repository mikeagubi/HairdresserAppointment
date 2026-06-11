using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class CancelBookingModel : PageModel
    {
        private readonly BookingApiService _bookingApiService;
        public CancelBookingModel(BookingApiService bookingApiService)
        {
            _bookingApiService = bookingApiService;
        }


        [BindProperty]
        public CancelBookingDto CancelBooking { get; set; }
        public string? ResponseMessage { get; set; }


        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostCancelBookingAsync()
        {
            var token = HttpContext.Session.GetString("token");

            ResponseMessage = await _bookingApiService.CancelBookingAsync(CancelBooking, token);

            return Page(); 
        }




    }
}
