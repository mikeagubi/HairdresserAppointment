using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class CreateBookingModel : PageModel
    {
        private readonly HairdresserApiService _hairdresserApiService;
        private readonly TreatmentApiService _treatmentApiService;
        private readonly BookingApiService _bookingApiService;
        private readonly PromotionApiService _promotionApiService;
        public CreateBookingModel(HairdresserApiService hairdresserApiService, TreatmentApiService treatmentApiService, 
            BookingApiService bookingApiService, PromotionApiService promotionApiService)
        {
            _hairdresserApiService = hairdresserApiService;
            _treatmentApiService = treatmentApiService;
            _bookingApiService = bookingApiService;
            _promotionApiService = promotionApiService;
        }

        [BindProperty(SupportsGet = true)]
        public int HairdresserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<int> TreatmentIds { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime StartTime { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndTime { get; set; }

        [BindProperty]
        public CreateBookingDto CreateBooking { get; set; } = new();

        public HairdresserBookingDto SelectedHairdresser { get; set; }
        public List<TreatmentDto> SelectedTreatments { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public int TotalTime { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            if(HairdresserId == 0 || 
                TreatmentIds == null || 
                TreatmentIds.Count == 0)
            {
                return ReturnToBookingPage();
            }

            SelectedHairdresser = await _hairdresserApiService
                .GetHairdresserByIdAsync(HairdresserId);

            SelectedTreatments = (await _treatmentApiService.GetAllTreatmentsAsync())
                .Where(t => TreatmentIds.Contains(t.Id))
                .ToList();

            if (SelectedTreatments.Count != TreatmentIds.Count ||
                SelectedHairdresser == null)
            {
                return ReturnToBookingPage();
            }

            TotalPrice = SelectedTreatments
                .Sum(t => t.Price);

            TotalTime = SelectedTreatments
                .Sum(t => t.DurationInMinutes);

            return Page();
        }


        public async Task<IActionResult> OnPostCreateBookingAsync()
        {
            var bookingNumber = await _bookingApiService.CreateBookingAsync(CreateBooking);

            if(string.IsNullOrEmpty(bookingNumber))
            {
                return ReturnToBookingPage();
            }

            TempData["BookingNumber"] = bookingNumber;
            return RedirectToPage("/Booking/BookingConfirmation");
        }

        private IActionResult ReturnToBookingPage()
        {
            TempData["ErrorMessage"] = ("Något gick fel. Försök igen.");

            return RedirectToPage("/Booking/SelectServices");
        }

    }
}
