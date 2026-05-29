using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class BookingConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string BookingNumber { get; set; }

        
        public void OnGet()
        {
        }
    }
}
