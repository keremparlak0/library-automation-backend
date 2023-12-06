using Models.DTOs;
using Models.Entities;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<object> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<AppUser> GetUserByIdAsync(string id);
        Task<object> LoginAsync(UserLoginDto userLoginDto);
        Task<TokenDto> RefreshLoginAsync(string refreshToken);
    }
}
