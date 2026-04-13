using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.AspNetCore.Identity;

namespace HairdresserAppointment.API.Services
{
    public class AuthService
    {
        private readonly MyDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public AuthService(MyDbContext context)
        {
            _context = context;
        }


        public async Task<bool> LoginUserAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if(user == null)
                return false;

            var userResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            return userResult.Succeeded;
        }






    }




}
