using Microsoft.AspNetCore.Identity;

namespace HairdresserAppointment.API.Models
{
    public class CustomUser : IdentityUser
    {
        public string? HairdresserName { get; set; }
        public int? HairdresserId { get; set; }
    }
}
