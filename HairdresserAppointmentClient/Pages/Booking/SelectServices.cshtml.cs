using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages.Booking
{
    public class SelectServicesModel : PageModel
    {
        private readonly TreatmentApiService _treatmentApiService;
        private readonly HairdresserApiService _hairdresserApiService;
        public SelectServicesModel(TreatmentApiService treatmentApiService, HairdresserApiService hairdresserApiService)
        {
            _treatmentApiService = treatmentApiService;
            _hairdresserApiService = hairdresserApiService;
        }

        public List<TreatmentDto> Treatments { get; set; } = new();
        public List<HairdresserDto> Hairdressers { get; set; } = new();



        [BindProperty]
        public int HairdresserId { get; set; }

        [BindProperty]
        public List<int> TreatmentIds { get; set; } = new();



        public async Task OnGet()
        {
            await LoadPageAsync();

        }


        public async Task<IActionResult> OnPostAddTreatmentsAsync(int treatmentId)
        {
            TreatmentIds.Add(treatmentId);
            await LoadPageAsync();
            return Page();
        }

        private async Task LoadPageAsync()
        {
            Treatments = await _treatmentApiService.GetAllTreatmentsAsync();
            Hairdressers = await _hairdresserApiService.GetHairdressersAsync();
        }




    }
}
