using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }
        
        //Service filter yaz
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody]UserRegistrationDto userDto)
        {
            var result = await _service.RegisterUser(userDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201, result.ToString);
        }
    }
}
