using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class SelectTimeModel : PageModel
    {
        private readonly HairdresserApiService _hairdresserApiService;
        private readonly TreatmentApiService _treatmentApiService;
        public SelectTimeModel(HairdresserApiService hairdresserApiService, TreatmentApiService treatmentApiService)
        {
            _hairdresserApiService = hairdresserApiService;
            _treatmentApiService = treatmentApiService;
        }

        public HairdresserBookingDto? SelectedHairdresser { get; set; }
        public List<TreatmentDto> SelectedTreatments { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public List<int> TreatmentIds { get; set; }

        [BindProperty(SupportsGet = true)]
        public int HairdresserId { get; set; }


        public async Task OnGet()
        {
            SelectedHairdresser = await _hairdresserApiService.GetHairdresserByIdAsync(HairdresserId);

            SelectedTreatments = (await _treatmentApiService.GetAllTreatmentsAsync())
                .Where(T => TreatmentIds.Contains(T.Id)).ToList();

           

        }









    }
}
