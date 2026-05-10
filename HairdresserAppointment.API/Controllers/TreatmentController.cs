using HairdresserAppointment.API.Services;
using Microsoft.AspNetCore.Mvc;
using HairdresserAppointment.API.Services;
using HairdresserAppointment.API.Models;

namespace HairdresserAppointment.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly TreatmentService _treatmentService;

        public TreatmentController(TreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }


        [HttpGet]
        public async Task<List<Treatment>> GetTreatments()
        {
            var treatments = await _treatmentService.GetAllTreatmentsAsync();

            return treatments;
        }


        [HttpPost]
        public async Task CreateTreatment(Treatment treatment)
        {
            await _treatmentService.CreateTreatmentAsync(treatment);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTreatment(Treatment dto)
        {
            var treatmentToUpdate = await _treatmentService.UpdateTreatmentAsync(dto);
            if (!treatmentToUpdate)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var deleted = await _treatmentService.DeleteTreatmentAsync(id);
            if(!deleted)
                return NotFound();

            return NoContent();

        }
    
    
    }



    
}
