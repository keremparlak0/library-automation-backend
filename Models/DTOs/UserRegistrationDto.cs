using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public record UserRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public required string? UserName { get; init; }
        public required string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }

        public required ICollection<string>? Roles { get; init; }
    }
}
