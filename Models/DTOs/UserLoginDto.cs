using System.ComponentModel;

namespace Models.DTOs
{
    public class UserLoginDto
    {
        [DefaultValue("info@kerem.com")]
        public string Email { get; set; }

        [DefaultValue("1233210")]
        public string Password { get; set; }
    }
}
