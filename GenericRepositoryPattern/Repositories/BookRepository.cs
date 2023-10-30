﻿using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using WebApi.Repositories.Contracts;

namespace WebApi.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> GetFirstBookName()
        {
            return await GetAll().Select(b => b.Name).FirstOrDefaultAsync();
        }
    }
}
