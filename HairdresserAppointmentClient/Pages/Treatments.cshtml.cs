using Azure.Core;
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





        public async Task OnGetAsync()
        {
            Treatments = await _treatmentsApiService.GetAllTreatments();

            
        }


        public async Task<IActionResult> OnPostCreateTreatmentAsync()
        {
            //var token = HttpContext.Session.GetString("token");
            var success = await _treatmentsApiService.CreateTreatmentAsync(Treatment);
            if (success)
            {
                TempData["CreateMessage"] = "New treatment added";
            }

            return RedirectToPage("/Treatments");
        }



        public async Task<IActionResult> OnPostUpdateTreatmentAsync()
        {
            var success = await _treatmentsApiService.UpdateTreatmentAsync(Treatment);
            if (!success)
            {
                TempData["Message"] = "Failed to update treatment";
            }
            else
            {
                TempData["Message"] = "Treatment updated";
            }
            return RedirectToPage("/Treatments");

        }

        public async Task<IActionResult> OnPostDeleteTreatmentAsync()
        {
            var success = await _treatmentsApiService.DeleteTreatmentAsync(Treatment.Id);

            return RedirectToPage("/treatments");
        }










    }
}
