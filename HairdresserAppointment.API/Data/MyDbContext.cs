using HairdresserAppointment.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAppointment.API.Data
{
    public class MyDbContext : IdentityDbContext<CustomUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Treatment>()
                .Property(t => t.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Promotion>()
                .Property(p => p.DiscountPercent)
                .HasPrecision(5, 2);
        }


    }
}
