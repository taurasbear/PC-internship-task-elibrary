namespace PCElibrary.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Enums;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Year = 1954, ImagePath = "/images/1984-george-orwell.jpg" },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Year = 1930, ImagePath = "/images/to-kill-a-mocking-bird.jpg" }
            );

            modelBuilder.Entity<BookType>().HasData(
                new BookType { Id = 1, Format = BookFormat.Physical, BookId = 1 },
                new BookType { Id = 2, Format = BookFormat.Audio, BookId = 2 }
            );
        }
    }
}
