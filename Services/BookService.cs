using AutoMapper;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using Models.Entities;
using Models.Exceptions;
using Repositories.Contracts;
using Services.Contracts;
using static Models.Exceptions.NotFoundException;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _repository.GetAll();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
            return bookDtos;
        }
        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await GetOneBookByIdAndCheckExists(id);
            return _mapper.Map<BookDto>(book);
        }
        public async Task<BookCreateDto> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            var book = _mapper.Map<Book>(bookCreateDto);
            await _repository.CreateAsync(book);

            return _mapper.Map<BookCreateDto>(book);
        }
        public async Task<Book> UpdateBookAsync(int id, BookDto bookDto)
        {
            var entity = await GetOneBookByIdAndCheckExists(id);
            entity = _mapper.Map<Book>(bookDto);
            _repository.UpdateAsync(entity);

            return entity;
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await GetOneBookByIdAndCheckExists(id);

            await _repository.DeleteAsync(book);
        }
        // check entity 
        private async Task<Book> GetOneBookByIdAndCheckExists(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                throw new BookNotFoundException(id);

            return entity;
        }
    }
}