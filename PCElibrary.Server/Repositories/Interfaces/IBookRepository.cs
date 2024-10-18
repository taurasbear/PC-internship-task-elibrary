using PCElibrary.Server.Services.BusinessModels;

namespace PCElibrary.Server.Repositories.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <returns>A collection of BookBusinessModel objects.</returns>
        Task<IEnumerable<BookBusinessModel>> GetAllBooksAsync();
    }
}
