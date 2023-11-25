using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Exceptions;
using Models.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateUserAsync([FromBody] UserRegisterDto userRegisterDto)
        {
            var result = await _userManager.CreateAsync(new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName
            }, userRegisterDto.Password);
            if (result.Succeeded)
                return StatusCode(201);
            else
            {
                foreach (var error in result.Errors)
                {
                    await Console.Out.WriteLineAsync(error.Description.ToString());
                }
                return result.Errors.ToList();
            }

        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) throw new UserNotFoundException(userLoginDto.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
            if (result.Succeeded)
            {
                return Ok("Giriş Yapıldı");
            }
            return Ok();
        }
    }
}
