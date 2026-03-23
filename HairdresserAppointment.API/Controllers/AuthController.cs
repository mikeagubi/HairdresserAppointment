using HairdresserAppointment.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AuthController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            
        }











    }
}
