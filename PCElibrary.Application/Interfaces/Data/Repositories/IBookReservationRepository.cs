using PCElibrary.Domain.Entities;

namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    public interface IBookReservationRepository
    {
        /// <summary>
        /// Adds a new book reservation to the repository asynchronously.
        /// </summary>
        /// <param name="bookReservation">The book reservation to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddBookReservationAsync(BookReservation bookReservation);
    }
}
