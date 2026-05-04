using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;

namespace HairdresserAppointmentClient.Pages
{
    public class HairdresserModel : PageModel
    {

        private readonly HairdresserApiService _hairdresserApiServices;
        private readonly AuthApiService _authApiService;
        public HairdresserModel(HairdresserApiService hairdresserApiService, AuthApiService authApiService)
        {
            _hairdresserApiServices = hairdresserApiService;
            _authApiService = authApiService;
        }

        public string ErrorMessage { get; set; }
        public List<HairdresserDto> Hairdressers { get; set; } = new();

        [BindProperty]
        public CreateHairdresserDto Hairdresser { get; set; } = new();

        [BindProperty]
        public CreateUserDto User { get; set; }




        public async Task OnGet()
        
        {
            Hairdressers = await _hairdresserApiServices.GetHairdressersAsync();

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

            return RedirectToPage("/hairdresser");
        }

        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            var success = await _authApiService.CreateUserAsync(User);
            if (!success)
            {
                ErrorMessage = "Failed To Create Account";
            }
            else
            {
                ErrorMessage = "Account Created";
            }
            return RedirectToPage("/hairdresser");

        }

        //Kontrollera att namn syns, tänk på namnet i DB om jag ska ha kvar eller ta bort i user!
        //Tänk på Redirect om de verkligen ska se ut så, 
        //tänk på meddelanden inte skapade än!
        //Fixa till layouten lite
        //Glöm inte valideringar!







    }
}
