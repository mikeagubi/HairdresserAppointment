using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class WorkingHourController : ControllerBase
    {
        private readonly WorkingHourService _workingHour;
        public WorkingHourController(WorkingHourService workingHour)
        {
            _workingHour = workingHour;
        }


        [Authorize(Roles = "Hairdresser")]
        [HttpGet("workhour-by-id")]
        public  async Task<ActionResult<List<WorkingHoursDto>>> GetWorkingHoursByHairdresserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var workingHours = await _workingHour.GetWorkingHoursByHairdresserIdAsync(userId);
            if(workingHours == null)
                return NotFound("No working hours were found");

            return Ok(workingHours);
        }














    }
}
