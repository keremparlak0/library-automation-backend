using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Refreshtoken { get; set; }
        public DateTime RefreshtokenEndDate { get; set; }
    }
}
