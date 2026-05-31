using HairdresserAppointmentClient.ApiServices;
using HairdresserAppointmentClient.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HairdresserAppointmentClient.Pages
{
    public class HairdresserPanelModel : PageModel
    {
        private readonly WorkingHourApiService _workinghourApiservice;
        private readonly BookingApiService _bookingApiService;
        public HairdresserPanelModel(WorkingHourApiService workinghourApiservice, BookingApiService bookingApiService)
        {
            _workinghourApiservice = workinghourApiservice;
            _bookingApiService = bookingApiService;
        }

        public List<WorkingHourDto> Workinghours { get; set; }
        public List<BookingDto> Bookings { get; set; }


        public async Task OnGet()
        {
            var token = HttpContext.Session.GetString("token");
            
            Workinghours = await _workinghourApiservice.GetWorkingHoursByHairdresserId(token);

            Bookings = (await _bookingApiService.GetHairdressersBookingsAsync(token))
                .Where(b => b.StartTime > DateTime.Now)
                .OrderBy(b => b.StartTime)
                .ToList();
        }
    }
}
