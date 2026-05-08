using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

            await LoadPageAsync();
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Hairdresser.WorkingHours = Hairdresser.WorkingHours
                .Where(w => w.Selected).ToList();

            var success = await _hairdresserApiServices.CreateWithTimeAsync(Hairdresser);

            if (success)
            {
                TempData["HairdresserMessage"] = $"{Hairdresser.Name} is now registered";
                TempData["HairdresserMessageType"] = "success";
            }
            else
            {
                TempData["HairdresserMessage"] = $"Failed to register hairdresser";
                TempData["HairdresserMessageType"] = "fail";
            }
              
            return RedirectToPage("/hairdresser");
        }

        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            var success = await _authApiService.CreateUserAsync(User);
            if (success)
            {
                TempData["AccountMessage"] = $"{User.Email} is now created";
                TempData["AccountMessageType"] = "success";
            }
            else
            {
                TempData["AccountMessage"] = $"Failed to create account";
                TempData["AccountMessageType"] = "fail";
            }
            return RedirectToPage("/Hairdresser");

        }

        private async Task LoadPageAsync()
        {
            Hairdressers = await _hairdresserApiServices.GetHairdressersAsync();

            Hairdresser.WorkingHours = Enum.GetValues<DayOfWeek>()
                .Select(d => new WorkingHourDto
                {
                    DayOfWeek = d
                }).ToList();
        }

        //Kontrollera att namn syns, tänk på namnet i DB om jag ska ha kvar eller ta bort i user!
        //Tänk på Redirect om de verkligen ska se ut så, 
        //tänk på meddelanden inte skapade än!
        //Fixa till layouten lite
        //Glöm inte valideringar!







    }
}
