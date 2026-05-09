using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages
{
    public class TreatmentsModel : PageModel
    {
        private readonly TreatmentApiService _treatmentsApiService;
        public TreatmentsModel(TreatmentApiService treatmentsApiService)
        {
            _treatmentsApiService = treatmentsApiService;
        }
        public List<TreatmentDto> Treatments { get; set; }





        public async Task OnGet()
        {
            Treatments = await _treatmentsApiService.GetAllTreatments();
        }











    }
}
