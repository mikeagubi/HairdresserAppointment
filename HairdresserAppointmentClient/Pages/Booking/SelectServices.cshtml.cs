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
        public List<TreatmentDto> SelectedTreatments { get; set; } = new();

        [BindProperty]
        public int HairdresserId { get; set; }



        public async Task OnGet()
        {
            Treatments = await _treatmentApiService.GetAllTreatmentsAsync();
            Hairdressers = await _hairdresserApiService.GetHairdressersAsync();

        }

        public async Task OnPostAsync()
        {

        }






    }
}
