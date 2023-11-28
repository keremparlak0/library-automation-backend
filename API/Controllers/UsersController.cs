using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateUserAsync([FromBody] UserRegisterDto userRegisterDto)
        {
            return Created("", await _userService.CreateUserAsync(userRegisterDto));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return Ok(await _userService.LoginAsync(userLoginDto));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> LoginWithRefreshToken([FromForm] RefreshTokenDto refreshTokenDto)
        {
            return Ok(await _userService.RefreshLoginAsync(refreshTokenDto.ToString()));
        }
    }
}
