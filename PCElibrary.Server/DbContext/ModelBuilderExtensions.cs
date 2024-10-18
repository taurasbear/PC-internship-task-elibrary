using Microsoft.EntityFrameworkCore;
using PCElibrary.Server.Repositories.Entities;

namespace PCElibrary.Server.DbContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Year = 1954, ImagePath = "/images/1984-george-orwell.jpg" },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Year = 1930, ImagePath = "/images/to-kill-a-mocking-bird.jpg" }
            );
        }
    }
}
