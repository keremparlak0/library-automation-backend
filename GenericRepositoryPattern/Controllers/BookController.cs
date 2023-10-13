using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entities;
using WebApi.Repositories.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _repository.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            _repository.Create(book);
            return Ok(book);
        }
    }
}
