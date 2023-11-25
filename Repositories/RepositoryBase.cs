using Microsoft.EntityFrameworkCore;
using Models.Contexts;
using Models.Entities;
using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
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
            var entity = await Table.Where(e => e.Id.Equals(id)).AsNoTracking().SingleOrDefaultAsync();
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
