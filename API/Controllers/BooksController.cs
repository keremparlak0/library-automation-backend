using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Contracts;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAllBooks();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreationDto bookCreateDto)
        {
            await _bookService.CreateBookAsync(bookCreateDto);
            return StatusCode(201, new { name = bookCreateDto.Name });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookUpdationDto bookUpdateDto)
        {
            await _bookService.UpdateBookAsync(id, bookUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
