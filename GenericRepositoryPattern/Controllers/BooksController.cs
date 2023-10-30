using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Services.Contracts;

namespace WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;
        public BookController(IMapper mapper, IBookService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(_service.GetAllBooks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            try
            {  
                return Ok(_service.GetBookByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }  

        //[HttpGet("first")]
        //public async Task<string> GetFirstBookName()
        //{
        //    try
        //    {
        //        var bookName = await _service.
        //        return bookName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            try
            {
                _service.CreateBookAsync(bookCreateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
            {
                await _service.DeleteBookAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
