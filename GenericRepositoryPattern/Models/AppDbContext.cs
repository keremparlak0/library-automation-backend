using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }
    }


}
