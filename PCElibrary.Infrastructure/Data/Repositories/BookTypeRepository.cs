namespace PCElibrary.Infrastructure.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Application.Interfaces;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class BookTypeRepository : BaseRepository, IBookTypeRepository
    {
        public BookTypeRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<IList<BookType>> GetBookTypesByBookId(long bookId, CancellationToken cancellationToken)
        {
            return await libraryContext.BookTypes
                .Where(bookType => bookType.BookId == bookId)
                .ToListAsync(cancellationToken);
        }
    }
}
