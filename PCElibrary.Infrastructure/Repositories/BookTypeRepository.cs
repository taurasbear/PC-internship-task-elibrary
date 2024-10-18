namespace PCElibrary.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Application.Interfaces;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Infrastructure.DbContext;

    public class BookTypeRepository : BaseRepository, IBookTypeRepository
    {
        public BookTypeRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<IList<BookType>> GetBookTypesByBookId(long bookId)
        {
            return await this.libraryContext.BookTypes
                .Where(bookType => bookType.BookId == bookId)
                .ToListAsync();
        }
    }
}
