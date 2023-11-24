using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Models.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book { Id = 1, UpdatedAt = DateTime.Now, Name = "Donusum", Author = "Kafka" });
            builder.HasData(new Book { Id = 2, UpdatedAt = DateTime.Now, Name = "The Godfather", Author = "Mario Puzo" });
            builder.HasData(new Book { Id = 3, UpdatedAt = DateTime.Now, Name = "Cesur Yeni Dunya", Author = "Aldous Huxley" });

        }
    }
}
