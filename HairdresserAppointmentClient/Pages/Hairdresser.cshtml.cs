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


        [BindProperty]
        public CreateHairdresserDto Hairdresser { get; set; } = new();

        [BindProperty]
        public CreateUserDto User { get; set; }

        public List<HairdresserDto> Hairdressers { get; set; } = new();



        public async Task<IActionResult> OnGet()
        
        {
            var role = HttpContext.Session.GetString("role");
            if(role != "Admin")
            {
                return RedirectToPage("/login");
            }

            Hairdressers = await _hairdresserApiServices.GetHairdressersAsync();
            LoadPage();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!Hairdresser.WorkingHours.Any(w => w.Selected))
            {
                TempData["HairdresserMessage"] = "Minst en arbetsdag måste vara markerad!";
            }
            else
            {
                var token = HttpContext.Session.GetString("token");

                Hairdresser.WorkingHours = Hairdresser.WorkingHours
                    .Where(w => w.Selected).ToList();

                var success = await _hairdresserApiServices.CreateWithTimeAsync(Hairdresser, token);

                if (success)
                {
                    TempData["HairdresserMessage"] = $"{Hairdresser.Name} is now registered";
                }
                else
                {
                    TempData["HairdresserMessage"] = $"Failed to register hairdresser";
                }
            }
            
            return Redirect("/Hairdresser");
        }


        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            var token = HttpContext.Session.GetString("token");

            var success = await _authApiService.CreateUserAsync(User, token);

            if (success)
            {
                TempData["AccountMessage"] = $"{User.Email} is now created";
            }
            else
            {
                TempData["AccountMessage"] = $"Failed to create account";
            }

            return Redirect("/Hairdresser");
        }


        public async Task<IActionResult> OnPostDeleteHairdresserAsync(int id)
        {
            var token = HttpContext.Session.GetString("token");
            var success = await _hairdresserApiServices.DeleteHairdresserAsync(id, token);

            if (success)
            {
                TempData["DeleteMessage"] = "Frisören är nu inaktiverad";
            }
            else
            {
                TempData["DeleteMessage"] = "Kunde inte Inaktivera frisören";
            }

            return Redirect("/Hairdresser#hairdressers");
        }


        private async Task LoadPage()
        {
            Hairdresser.WorkingHours = Enum.GetValues<DayOfWeek>()
                .Select(d => new WorkingHourDto
                {
                    DayOfWeek = d
                }).ToList();
        }



        public string GetSwedishDays(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "Måndag",
                DayOfWeek.Tuesday => "Tisdag",
                DayOfWeek.Wednesday => "Onsdag",
                DayOfWeek.Thursday => "Torsdag",
                DayOfWeek.Friday => "Fredag",
                DayOfWeek.Saturday => "Lördag",
                DayOfWeek.Sunday => "Söndag",
            };
        }



    }
}
