using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class HairdresserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
