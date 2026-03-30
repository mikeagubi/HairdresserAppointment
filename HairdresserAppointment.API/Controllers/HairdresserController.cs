using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using HairdresserAppointment.API.Services;
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

        [HttpPost("create-with-time")]
        public async Task CreateWithTime(CreateHairdresserDto dto)
        {
            await _hairdresserService.CreateStackAsync(dto);
        }

        [HttpPost]
        public async Task CreateHairdresser(Hairdresser hairdresser)
        {
            await _hairdresserService.CreateHairdresserAsync(hairdresser);
        }














    }
}
