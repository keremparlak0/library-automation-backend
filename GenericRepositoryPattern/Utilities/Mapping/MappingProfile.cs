using AutoMapper;
using WebApi.Models.DTOs;
using WebApi.Models.Entities;

namespace WebApi.Utilities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookCreateDto>();
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, Book>();
        }
    }
}
