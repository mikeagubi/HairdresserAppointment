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




        public async Task<IActionResult> OnGet()
        
        {

            await LoadPageAsync();

            return Page();
        }


        //skapa med tid
        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("role");
            var token = HttpContext.Session.GetString("token");

            Hairdresser.WorkingHours = Hairdresser.WorkingHours
                .Where(w => w.Selected).ToList();

            var success = await _hairdresserApiServices.CreateWithTimeAsync(Hairdresser, token);

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


        //skapa account för Hairdressern
        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            var role = HttpContext.Session.GetString("role");
            var token = HttpContext.Session.GetString("token");

            var success = await _authApiService.CreateUserAsync(User, token);
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
            var role = HttpContext.Session.GetString("role");
            var token = HttpContext.Session.GetString("token");

            Hairdressers = await _hairdresserApiServices.GetHairdressersAsync(token);

            Hairdresser.WorkingHours = Enum.GetValues<DayOfWeek>()
                .Select(d => new WorkingHourDto
                {
                    DayOfWeek = d
                }).ToList();
        }


        //Glöm inte valideringar!







    }
}
