using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Models.RequestModels.File;
using Models.ViewModel;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public UsersController(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService;
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

        [HttpPost("[action]")]
        public IActionResult Post([FromBody] PostRM model)
        {
            //_fileService.FileFromBase64(model.Base64, model.FileName, model.);

            return Ok(model);
        }
    }
}
