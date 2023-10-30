using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entities;
using WebApi.Repositories.Contracts;

namespace WebApi.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll()
        {
            return Table.AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await Table.AsNoTracking().Where(e => e.Id.Equals(id)).SingleOrDefaultAsync();
            return entity;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        

        

        
    }
}
