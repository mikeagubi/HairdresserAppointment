using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class BookingConfirmationModel : PageModel
    {
        public string? BookingNumber { get; set; }

        
        public IActionResult OnGet()
        {
            BookingNumber = TempData["BookingNumber"]?.ToString();

            if (string.IsNullOrWhiteSpace(BookingNumber))
            {
                return RedirectToPage("/Booking/SelectServices");
            }
            return Page();
        }
    }
}
