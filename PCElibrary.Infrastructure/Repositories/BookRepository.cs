namespace PCElibrary.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Enums;
    using PCElibrary.Infrastructure.DbContext;
    using PCElibrary.Server.Repositories.Interfaces;

    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<IList<Book>> GetAllBooksAsync(string title, int? year, BookFormat? type)
        {
            var bookQuery = this.libraryContext.Books
                .Include(book => book.BookTypes)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                bookQuery = bookQuery.Where(book => book.Title.ToLower().Contains(title.ToLower()));
            }

            if (year.HasValue)
            {
                bookQuery = bookQuery.Where(book => book.Year == year.Value);
            }

            if (type.HasValue)
            {
                bookQuery = bookQuery.Where(book => book.BookTypes.Any(bookType => bookType.Format == type.Value));
            }

            return await bookQuery.ToListAsync();
        }
    }
}
