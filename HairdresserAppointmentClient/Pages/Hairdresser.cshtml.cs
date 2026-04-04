using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.Pages
{
    public class HairdresserModel : PageModel
    {

        private readonly HairdresserApiService _hairdresserApiServices;
        public HairdresserModel(HairdresserApiService hairdresserApiService)
        {
            _hairdresserApiServices = hairdresserApiService;
        }

        [BindProperty]
        public CreateHairdresserDto Hairdresser { get; set; } = new();




        public void OnGet()
        
        {
            Hairdresser.WorkingHours = Enum.GetValues<DayOfWeek>()
                .Select(d => new WorkingHourDto
                {
                    DayOfWeek = d
                }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Hairdresser.WorkingHours = Hairdresser.WorkingHours
                .Where(w => w.Selected).ToList();

            var success = await _hairdresserApiServices.CreateWithTimeAsync(Hairdresser);
            if (!success)
                return Page();

            return RedirectToPage("/Index");
        }











    }
}
