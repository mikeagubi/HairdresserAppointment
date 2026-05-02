using HairdresserAppointment.API.Data;
using HairdresserAppointment.API.DTO;
using HairdresserAppointment.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


        public async Task<bool> CreateUserAsync(CreateUserDto dto)
        {

            var exist = await _context.Hairdressers
                .AnyAsync(h => h.Id == dto.HairdresserId);
            if (!exist)
                return false;

            var user = new CustomUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                HairdresserId = dto.HairdresserId,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return false;

            await _userManager.AddToRoleAsync(user, "Hairdresser");

            return true;
        
        }






    }




}
