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


        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginDto dto)
        {
            var token = await _authService.LoginUserAsync(dto);
            if(token == null)
                return Unauthorized("Wrong Email or Password");

            return Ok(new {token});
        }


        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var reult = await _authService.CreateUserAsync(dto);
            if (!reult)
                return BadRequest("Cant create user");

            return Ok("user created");
        }




        //PUT ENDAST på changeID för Hairdresser


        //Bygga delete Users










    }
}
