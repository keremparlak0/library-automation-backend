using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Models.DTOs;
using Models.Entities;
using Models.ErrorModel;
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
            IdentityResult result = await _userManager.CreateAsync(new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Status = userRegisterDto.Status
            }, userRegisterDto.Password);

            if (result.Succeeded)
                return new
                {
                    message = $"The user was created with ${userRegisterDto.Email}.",
                    statusCode = 201
                };
            else
            {
                foreach (var error in result.Errors)
                {
                    await Console.Out.WriteLineAsync(error.Description.ToString());
                }
                throw new UserRegistrationFailedException(new ErrorResponse()
                {
                    Description = result.Errors.FirstOrDefault().Description,//for now
                    StatusCode = 403
                });
            }
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new NotFoundUserException();

            return user;
        }

        public async Task<object> LoginAsync(UserLoginDto userLoginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);
            if (result.Succeeded)
            {
                TokenDto token = _tokenService.CreateSecurityToken(second: 20);

                #region UpdateRefreshToken
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddHours(1);
                await _userManager.UpdateAsync(user);
                #endregion

                return new
                {
                    accessToken = $"{token.AccessToken}",
                    refreshToken = token.RefreshToken,
                    tokenType = "bearer",
                    user = new
                    {
                        avatar = user.Avatar,
                        email = user.Email,
                        id = user.Id,
                        name = user.UserName,
                        status = user.Status
                    }
                };
            }
            throw new AuthenticationErrorException();
        }

        public async Task<TokenDto> RefreshLoginAsync(string refreshToken)
        {
            AppUser? user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto token = _tokenService.CreateSecurityToken(second: 30);

                #region UpdateRefreshToken
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddSeconds(30);
                await _userManager.UpdateAsync(user);
                #endregion

                await Console.Out.WriteLineAsync(refreshToken + "\n" + user.RefreshToken + " <=> " + user.RefreshTokenEndDate);
                return new TokenDto
                {
                    AccessToken = token.AccessToken
                };
            }
            else
                throw new NotFoundUserException();

        }
    }
}
