using System.ComponentModel;

namespace Models.DTOs
{
    public class UserRegisterDto
    {
        [DefaultValue("kerem")]
        public string FirstName { get; set; }

        [DefaultValue("parlak")]
        public string LastName { get; set; }

        [DefaultValue("keremprlk")]
        public string UserName { get; set; }

        [DefaultValue("info@kerem.com")]
        public string Email { get; set; }

        [DefaultValue("1233210")]
        public string Password { get; set; }
        [DefaultValue("online")]
        public string Status { get; set; }

    }
}
