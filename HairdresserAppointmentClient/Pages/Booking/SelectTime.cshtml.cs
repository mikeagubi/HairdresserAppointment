using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using HairdresserAppointmentClient.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class SelectTimeModel : PageModel
    {
        private readonly HairdresserApiService _hairdresserApiService;
        private readonly TreatmentApiService _treatmentApiService;
        private readonly BookingHelper _bookingHelper;
        public SelectTimeModel(HairdresserApiService hairdresserApiService, TreatmentApiService treatmentApiService, BookingHelper bookingHelper)
        {
            _hairdresserApiService = hairdresserApiService;
            _treatmentApiService = treatmentApiService;
            _bookingHelper = bookingHelper;
        }

        public HairdresserBookingDto? SelectedHairdresser { get; set; }
        public List<TreatmentDto> SelectedTreatments { get; set; }


        public List<DateTime> AvailableSlots { get; set; } = new();

        
        [BindProperty(SupportsGet = true)]
        public List<int> TreatmentIds { get; set; }

        [BindProperty(SupportsGet = true)]
        public int HairdresserId { 
            get; set; }


        public async Task OnGet()
        {
            if (HairdresserId == 0 || TreatmentIds == null)
            {
                return;
            }
            SelectedTreatments = (await _treatmentApiService.GetAllTreatmentsAsync())
                .Where(T => TreatmentIds.Contains(T.Id)).ToList();

            SelectedHairdresser = await _hairdresserApiService.GetHairdresserByIdAsync(HairdresserId);


            AvailableSlots = _bookingHelper.GenerateTimeSlots(SelectedHairdresser, SelectedTreatments);
           

        }









    }
}
