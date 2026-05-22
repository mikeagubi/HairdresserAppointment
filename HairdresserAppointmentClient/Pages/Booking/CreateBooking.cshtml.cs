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
        public CreateBookingModel(HairdresserApiService hairdresserApiService, TreatmentApiService treatmentApiService, BookingApiService bookingApiService)
        {
            _hairdresserApiService = hairdresserApiService;
            _treatmentApiService = treatmentApiService;
            _bookingApiService = bookingApiService;
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
        public CreateBookingDto Booking { get; set; } = new();

        public HairdresserBookingDto SelectedHairdresser { get; set; }
        public List<TreatmentDto> SelectedTreatments { get; set; }
        public decimal TotalPrice { get; set; }

        public int TotalTime { get; set; }



        public async Task OnGet()
        {
            if(HairdresserId == 0 || TreatmentIds == null)
            {
                return;
            }
            SelectedHairdresser = await _hairdresserApiService.GetHairdresserByIdAsync(HairdresserId);
            SelectedTreatments = (await _treatmentApiService.GetAllTreatmentsAsync())
                .Where(t => TreatmentIds.Contains(t.Id)).ToList();
            TotalPrice = SelectedTreatments.Sum(t => t.Price);
            TotalTime = SelectedTreatments.Sum(t => t.DurationInMinutes);
        }



        public async Task<IActionResult> OnPostCreateBookingAsync()
        {
            var success = await _bookingApiService.CreateBookingAsync(Booking);
            if (!success)
            {
                return Page();
            }
            return RedirectToPage("/Booking/BookingConfirmation");
        }
    }
}
