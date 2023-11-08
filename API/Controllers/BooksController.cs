using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_service.GetAllBooks());
        }

        //[Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _service.GetBookByIdAsync(id);
            return Ok(book);
        }

        //[HttpGet("first")]
        //public async Task<string> GetFirstBookName()
        //{
        //        var bookName = await _service.
        //        return bookName;
        //}

        //[Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreationDto bookCreateDto)
        {
            _service.CreateBookAsync(bookCreateDto);
            return StatusCode(201,new { name = bookCreateDto.Name});
        }

        //[Authorize(Roles = "User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookUpdationDto bookUpdateDto)
        {
            await _service.UpdateBookAsync(id, bookUpdateDto);
            return NoContent(); // 204
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _service.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
