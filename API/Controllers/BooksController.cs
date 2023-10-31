using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService service, ILogger<BooksController> logger)
        {
            _service = service;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into BooksController");
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("GetAllBooks method is logged.");
            return Ok(_service.GetAllBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = _service.GetBookByIdAsync(id);
            return Ok(book);
        }

        //[HttpGet("first")]
        //public async Task<string> GetFirstBookName()
        //{
        //        var bookName = await _service.
        //        return bookName;
        //}

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            _service.CreateBookAsync(bookCreateDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookDto bookDto)
        {
            await _service.UpdateBookAsync(id, bookDto);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _service.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
