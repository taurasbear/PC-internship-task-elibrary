namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    using PCElibrary.Domain.Entities;

    public interface IBookTypeRepository
    {
        /// <summary>
        /// Retrieves a list of book types by book id asynchronously.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of book types.</returns>
        Task<IList<BookType>> GetBookTypesByBookId(long bookId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a book type by its id asynchronously.
        /// </summary>
        /// <param name="bookTypeId">The id of the book type.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The book type object.</returns>
        Task<BookType> GetBookTypeByIdAsync(long bookTypeId, CancellationToken cancellationToken);
    }
}
