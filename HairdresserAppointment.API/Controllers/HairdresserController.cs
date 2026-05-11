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



        [Authorize(Roles = "Admin")]
        [HttpPost("create-with-time")]
        public async Task CreateWithTime(CreateHairdresserDto dto)
        {
            await _hairdresserService.CreateStackAsync(dto);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<List<HairdresserDto>> GetHairdressers()
        {
            var hairdressers = await _hairdresserService.GetAllHairdressersAsync();

            return  hairdressers;
        }

 




        //skapa PUT men inte en hel PUT utan kanske bara från active till false ? 

        














    }
}
