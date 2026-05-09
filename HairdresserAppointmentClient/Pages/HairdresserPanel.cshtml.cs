using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages
{
    public class HairdresserPanelModel : PageModel
    {
        private readonly WorkingHourApiService _workinghourApiservice;
        public HairdresserPanelModel(WorkingHourApiService workinghourApiservice)
        {
            _workinghourApiservice = workinghourApiservice;
        }

        public List<WorkingHourDto> Workinghours { get; set; }


        public async Task OnGet()
        {
            var token = HttpContext.Session.GetString("token");
            Workinghours = await _workinghourApiservice.GetWorkingHoursByHairdresserId(token);
        
        }
    }
}
