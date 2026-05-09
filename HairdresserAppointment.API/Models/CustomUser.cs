using Microsoft.AspNetCore.Identity;

namespace HairdresserAppointment.API.Models
{
    public class CustomUser : IdentityUser
    {
        public int? HairdresserId { get; set; }
    }
}
