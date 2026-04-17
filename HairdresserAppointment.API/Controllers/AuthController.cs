using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;


        public AuthController(AuthService authService, 
            UserManager<CustomUser> userManager, 
            SignInManager<CustomUser> signInManager)
        {
            _authService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginDto dto)
        {
            var success = await _authService.LoginUserAsync(dto);
            if (!success)
                return Unauthorized("Wrong Email or Password");

            return Ok("Login Succeed");
        }


        //PUT ENDAST på changeID för Hairdresser

        //Bygga Create users,

        //Bygga delete Users










    }
}
