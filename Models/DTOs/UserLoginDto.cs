namespace Models.DTOs
{
    public record UserLoginDto
    {
        public required string? UserName { get; init; }
        public required string? Password { get; init; }
    }
}
