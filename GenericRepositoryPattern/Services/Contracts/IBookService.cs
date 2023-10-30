using WebApi.Models.DTOs;
using WebApi.Models.Entities;

namespace WebApi.Services.Contracts
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
