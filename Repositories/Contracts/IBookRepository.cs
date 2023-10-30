using Models.Entities;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<string> GetFirstBookName();
    }
}
