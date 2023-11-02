using Microsoft.AspNetCore.Identity;
using Models.DTOs;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userDtoForRegistration);
    }
}
