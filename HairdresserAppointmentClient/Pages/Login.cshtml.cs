using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HairdresserAppointmentClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthApiService _authApiService;
        public LoginModel(AuthApiService authApiService)
        {
            _authApiService = authApiService;
        }


        [BindProperty]
        public LoginDto loginDto { get; set; }
        public string Role { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            Role = HttpContext.Session.GetString("role");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = await _authApiService.LoginAsync(loginDto);
            if(token == null)
            {
                ErrorMessage = "Wrong Email Or Password";
                return Page();
            }

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var role = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            HttpContext.Session.SetString("jwt", token);
            HttpContext.Session.SetString("role", role);
            return RedirectToPage("/hairdresser");
        }



    }
}
