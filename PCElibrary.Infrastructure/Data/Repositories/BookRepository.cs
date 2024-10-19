namespace PCElibrary.Infrastructure.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Application.Interfaces.Data.Repositories;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Enums;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<IList<Book>> GetAllBooksAsync(string title, int? year, BookFormat? type, CancellationToken cancellationToken)
        {
            var bookQuery = libraryContext.Books
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

            return await bookQuery.ToListAsync(cancellationToken);
        }
    }
}
