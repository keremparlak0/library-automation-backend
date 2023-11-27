﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Models.DTOs;
using Models.Entities;
using Models.Exceptions;
using Services.Contracts;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserService(ITokenService tokenService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<object> CreateUserAsync(UserRegisterDto userRegisterDto)
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
                return new { 
                    message = $"The user was created with ${userRegisterDto.Email}.",
                    statusCode = 201                
                };
            else
            {
                foreach (var error in result.Errors)
                {
                    await Console.Out.WriteLineAsync(error.Description.ToString());
                }
                throw new Exception();
                /*return new
                {
                    result = result.Errors.ToList(),
                    statusCode = 400
                };*/
            }
        }

        public async Task<TokenDto> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) throw new UserNotFoundException(userLoginDto.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
            if (result.Succeeded)
            {
                TokenDto token = _tokenService.CreateSecurityToken(minute: 5);
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}
