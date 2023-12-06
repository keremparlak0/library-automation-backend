using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Models.ViewModel;
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

        [HttpGet]
        public async Task<ActionResult> GetUserById(string id)
        {
            AppUser user = await _userService.GetUserByIdAsync(id);
            GetUserVM userVM = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Avatar = user.Avatar
            };
            return Ok(userVM);
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

        [HttpPost("[action]")]
        public async Task<ActionResult> LoginWithRefreshToken([FromForm] RefreshTokenDto refreshTokenDto)
        {
            return Ok(await _userService.RefreshLoginAsync(refreshTokenDto.RefreshToken));
        }
    }
}
