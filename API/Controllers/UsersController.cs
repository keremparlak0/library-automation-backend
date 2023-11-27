﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Exceptions;
using Models.DTOs;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Services;
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
    }
}
