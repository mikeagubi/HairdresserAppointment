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



        //hämta bookingen sen!!!!! byt ut denna
        public int MyProperty { get; set; }


        public void OnGet()
        {

        }



        public async Task<IActionResult> OnPostCancelBookingAsync()
        {
            return null;

        }




    }
}
