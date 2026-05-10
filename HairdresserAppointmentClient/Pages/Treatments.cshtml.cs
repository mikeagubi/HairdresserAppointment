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

        public List<TreatmentDto> Treatments { get; set; } = new();

        [BindProperty]
        public TreatmentDto Treatment { get; set; }

        [BindProperty]
        public string Message { get; set; }





        public async Task OnGetAsync()
        {
            Treatments = await _treatmentsApiService.GetAllTreatments();

            
        }


        public async Task<IActionResult> OnPostCreateTreatmentAsync()
        {
            //var token = HttpContext.Session.GetString("token");
            await _treatmentsApiService.CreateTreatmentAsync(Treatment);

            return RedirectToPage("/Treatments");

        }

        public async Task<IActionResult> OnPostUpdateTreatmentAsync()
        {
            await _treatmentsApiService.UpdateTreatmentAsync(Treatment);

            return RedirectToPage("/Treatments");

        }










    }
}
