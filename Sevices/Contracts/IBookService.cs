using Models.DTOs;
using Models.Entities;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookCreateDto> CreateBookAsync(BookCreateDto bookCreateDto);
        Task<Book> UpdateBookAsync(int id, BookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
