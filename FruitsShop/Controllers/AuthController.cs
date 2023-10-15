using FruitsShop.Data;
using FruitsShop.Dto;
using FruitsShop.Dtos;
using FruitsShop.Helpers;
using FruitsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FruitsShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public AuthController(IUserRepository repository, JwtService jwtService, UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _repository = repository;
            _jwtService = jwtService;
            _userManager = userManager;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "This email already exists!"
                });
            }

            var user = new ApplicationUser
            {
                FullName = dto.Name,
                UserName = dto.Email,
                Email = dto.Email,
            };


            // if (!(await _userManager.CheckPasswordAsync(user, dto.Password))) return BadRequest(new { message = "Invalid Credentials" });

            var token = _jwtService.Generate(user.Id);

            var userIdStorage = user.Id;


            var fullName = user.FullName;


            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true
            });

            IdentityResult results = await _userManager.CreateAsync(user, dto.Password);

            var result = await _context.SaveChangesAsync() > 0;

            if (results.Succeeded)
                await _context.SaveChangesAsync();
          

            return Ok(new
            {
                message = "success",
                user,
                token,
                userIdStorage,
                fullName
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!(await _userManager.CheckPasswordAsync(user, dto.Password))) return BadRequest(new { message = "Invalid Credentials" });

            var token = _jwtService.Generate(user.Id);

            var userIdStorage = user.Id;

            var fullName = user.FullName;


            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success",
                user,
                token,
                userIdStorage,
                fullName
            });

        }
    }
}
