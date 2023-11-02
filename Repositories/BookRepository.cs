using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using Repositories.Contracts;

namespace Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> GetFirstBookName()
        {
            return await GetAll().Select(b => b.Name).FirstOrDefaultAsync();
        }
    }
}
