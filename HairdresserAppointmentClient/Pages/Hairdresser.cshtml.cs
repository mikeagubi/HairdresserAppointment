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

        public List<HairdresserDto> Hairdressers { get; set; }

        [BindProperty]
        public CreateHairdresserDto Hairdresser { get; set; } = new();




        public async Task OnGet()
        
        {
            Hairdresser.WorkingHours = Enum.GetValues<DayOfWeek>()
                .Select(d => new WorkingHourDto
                {
                    DayOfWeek = d
                }).ToList();

            Hairdressers = await _hairdresserApiServices.GetHairdressersAsync();
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
