using WebApi.Models.Entities;

namespace WebApi.Repositories.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<string> GetFirstBookName();
    }
}
