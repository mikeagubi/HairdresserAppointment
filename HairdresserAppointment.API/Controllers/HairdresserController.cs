using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class HairdresserController : ControllerBase
    {
        private readonly HairdresserService _hairdresserService;
        public HairdresserController(HairdresserService hairdresserService)
        {
            _hairdresserService = hairdresserService;
        }


        //Skapa frisör

        [Authorize(Roles = "Admin")]
        [HttpPost("create-with-time")]
        public async Task CreateWithTime(CreateHairdresserDto dto)
        {
            await _hairdresserService.CreateHairdresserAsync(dto);
        }


        //Hämta alla frisörer

        [HttpGet]
        public async Task<List<HairdresserDto>> GetHairdressers()
        {
            var hairdressers = await _hairdresserService.GetAllHairdressersAsync();

            return  hairdressers;
        }

        //Hämta frisör via Id

        [HttpGet("{id}")]
        public async Task<ActionResult<HairdresserBookingDto>> GetHairdresserById(int id)
        {
            var hairdresser = await _hairdresserService.GetHairdresserByIdAsync(id);

            if (hairdresser == null)
                return NotFound();

            return Ok(hairdresser);
        }


        //Soft-delete frisör

        [Authorize(Roles = "Admin")]
        [HttpPut("delete/{id}")]
        public async Task<IActionResult> DeleteHairdresser(int id)
        {
            var success = await _hairdresserService.DeleteHairdresserAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
















    }
}
