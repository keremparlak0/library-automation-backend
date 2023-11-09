using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Config;
using Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfig());

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "User", NormalizedName = "User" },
                new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
        }
    }
}
