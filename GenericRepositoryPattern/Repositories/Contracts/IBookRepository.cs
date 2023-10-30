using WebApi.Models.DTOs;
using WebApi.Models.Entities;

namespace WebApi.Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<string> GetFirstBookName();
    }
}
