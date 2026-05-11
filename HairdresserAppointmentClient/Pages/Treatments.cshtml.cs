using Azure.Core;
using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Authorization;
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




        
        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("role");
            if(role != "Admin")
            {
                return RedirectToPage("/login");
            }
            Treatments = await _treatmentsApiService.GetAllTreatments();

            return Page();

        }


        public async Task<IActionResult> OnPostCreateTreatmentAsync()
        {
            var token = HttpContext.Session.GetString("token");

            var success = await _treatmentsApiService.CreateTreatmentAsync(Treatment, token);
            if (success)
            {
                TempData["CreateMessage"] = "New treatment added";
            }

            return RedirectToPage("/Treatments");
        }



        public async Task<IActionResult> OnPostUpdateTreatmentAsync()
        {
            var token = HttpContext.Session.GetString("token");

            var success = await _treatmentsApiService.UpdateTreatmentAsync(Treatment, token);
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
            var token = HttpContext.Session.GetString("token");

            var success = await _treatmentsApiService.DeleteTreatmentAsync(Treatment.Id, token);
            if (!success)
            {
                TempData["Message"] = "Failed to delete treatment";
            }
            else
            {
                TempData["Message"] = "Treatment deleted";
            }

            return RedirectToPage("/treatments");
        }










    }
}
