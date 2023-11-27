using Models.DTOs;

namespace Services.Contracts
{
    public interface ITokenService
    {
        TokenDto CreateSecurityToken(int second);
        string CreateRefreshToken();
    }
}
