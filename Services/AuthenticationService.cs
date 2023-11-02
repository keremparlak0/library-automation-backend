using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.DTOs;
using Models.Entities;
using Services.Contracts;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationService(ILoggerService loggerService, IMapper mapper, UserManager<User> userManager, IConfiguration config)
        {
            _loggerService = loggerService;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userDtoForRegistration)
        {
            var user = _mapper.Map<User>(userDtoForRegistration);
            var result = await _userManager.CreateAsync(user, userDtoForRegistration.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userDtoForRegistration.Roles);
            }
            return result;
        }
    }
}
