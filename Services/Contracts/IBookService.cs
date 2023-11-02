using Models.DTOs;
using Models.Entities;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookCreationDto> CreateBookAsync(BookCreationDto bookCreateDto);
        Task<Book> UpdateBookAsync(int id, BookUpdationDto bookUpdateDto);
        Task DeleteBookAsync(int id);
    }
}
