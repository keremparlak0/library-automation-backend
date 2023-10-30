using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book {Id = 1, CratedAt = DateTime.Now, Name = "Donusum", Author = "Kafka"});
        }
    }


}
