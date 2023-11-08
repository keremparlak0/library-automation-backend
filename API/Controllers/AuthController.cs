using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AuthController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserRegistrationDto userDto)
        {

            var applicationUser = new ApplicationUser()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber

            };
            var result = await _userManager.CreateAsync(applicationUser, userDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(applicationUser, userDto.Roles);

            return Ok(result);
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] AppliCationUserDto userDto)
        //{
        //    if (user.Username != userDto.Username)
        //        return BadRequest("User not found");
        //    if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
        //        return BadRequest("Wrong password");

        //    string token = CreateToken(user);

        //    return Ok(token);
        //}

        //private string CreateToken(AppliCationUserDto user)
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Role, "Admin"),
        //        new Claim(ClaimTypes.Role, "User")
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration
        //        .GetSection("Authentication:Schemes:Bearer:SigningKeys:0:Value").Value));

        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //            claims: claims,
        //            expires: DateTime.Now.AddDays(1),
        //            signingCredentials: credentials
        //        );
        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}
    }
}
