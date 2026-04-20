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
        private readonly TokenService _tokenService;
        public AuthService(MyDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, TokenService tokenService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }


        public async Task<string?> LoginUserAsync(LoginDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            if(user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
            if (!result.Succeeded)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            var token = _tokenService.GenerateToken(user, role);

            return token;
        }






    }




}
