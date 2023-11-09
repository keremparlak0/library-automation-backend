using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.DTOs;
using Models.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AuthController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
        {

            var applicationUser = new User()
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

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            if (user is null)
                return BadRequest("User not found");

            if (!await _userManager.CheckPasswordAsync(user, userDto.Password))
                return BadRequest("Wrong password");

            string token = await CreateToken(userDto);

            return Ok(token);
        }

        private async Task<string> CreateToken(UserLoginDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);
            var jwtSettings = _configuration.GetSection("JwtSettings");

            #region Claims
            var userRoles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userDto.UserName),
                };
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            #endregion

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JwtSettings:secretKey").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            await Console.Out.WriteLineAsync(jwtSettings["validIssuer"]);
            var token = new JwtSecurityToken(
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    claims: claims,
                    signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            await _userManager.UpdateAsync(user);

            return jwt;
        }
    }
}
