using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
