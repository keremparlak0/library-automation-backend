using Models.DTOs;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<object> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<TokenDto> LoginAsync(UserLoginDto userLoginDto);
    }
}
