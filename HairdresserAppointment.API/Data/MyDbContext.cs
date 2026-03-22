using HairdresserAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }




    }
}
