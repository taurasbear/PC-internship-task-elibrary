namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Enums;

    public interface IBookRepository
    {
        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <param name="title">The title of the book (optional).</param>
        /// <param name="year">The year of publication (optional).</param>
        /// <param name="type">The format of the book (optional).</param>
        /// <returns>A collection of Book objects.</returns>
        Task<IList<Book>> GetAllBooksAsync(string title, int? year, BookFormat? type, CancellationToken cancellationToken);
    }
}
