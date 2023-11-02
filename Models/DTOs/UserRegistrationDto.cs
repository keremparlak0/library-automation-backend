using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public record UserRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init;}

        [Required(ErrorMessage = "Username is req.")]
        public string? Username { get; init;}

        [Required(ErrorMessage = "Email is req.")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is req.")]
        public string? Password { get; init; }
        public string? PhoneNumber{ get; init; }
        public ICollection<string> Roles { get; init; }
    }
}
