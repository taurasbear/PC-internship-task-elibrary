namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    using PCElibrary.Domain.Entities;

    public interface IBookTypeRepository
    {
        /// <summary>
        /// Retrieves book types by book id asynchronously.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        /// <returns>A collection of string objects.</returns>
        Task<IList<BookType>> GetBookTypesByBookId(long bookId, CancellationToken cancellationToken);
    }
}
