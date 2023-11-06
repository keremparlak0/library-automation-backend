using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace API.Utilities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookCreationDto>();
            CreateMap<BookCreationDto, Book>();
            CreateMap<Book, BookUpdationDto>();
            CreateMap<BookUpdationDto, Book>();
            CreateMap<Book, Book>();

        }
    }
}
