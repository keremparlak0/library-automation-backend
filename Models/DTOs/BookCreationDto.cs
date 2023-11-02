using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public record BookCreationDto
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; init; }

        [Required(ErrorMessage = "Author is required!")]
        [StringLength(50, MinimumLength = 6)]
        public string Author { get; init; }
    }
}
