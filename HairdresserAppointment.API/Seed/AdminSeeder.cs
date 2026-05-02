using HairdresserAppointment.API.Models;
using Microsoft.AspNetCore.Identity;

namespace HairdresserAppointment.API.Seed
{
    public class AdminSeeder
    {
        public static async Task AdminSeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<CustomUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var configuration = services.GetRequiredService<IConfiguration>();

            var adminEmail = configuration["AdminSettings:Email"];
            var adminPassword = configuration["AdminSettings:Password"];
            var adminRole = configuration["AdminSettings:Role"];

            if(!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (!await roleManager.RoleExistsAsync("Hairdresser"))
            {
                await roleManager.CreateAsync(new IdentityRole("Hairdresser"));
            }

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if(admin == null)
            {
                admin = new CustomUser{ Email = adminEmail, UserName = adminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(admin, adminPassword);
            }

            if(!await userManager.IsInRoleAsync(admin, adminRole))
            {
                await userManager.AddToRoleAsync(admin, adminRole);
            }
           

        }
    }
}
