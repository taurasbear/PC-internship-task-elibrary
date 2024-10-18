using PCElibrary.Server.Controllers.DTOs;

namespace PCElibrary.Server.Services.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <returns>A collection of BookDTO objects.</returns>
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
    }
}
