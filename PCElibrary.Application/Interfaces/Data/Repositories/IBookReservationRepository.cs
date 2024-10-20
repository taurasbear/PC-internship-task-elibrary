using PCElibrary.Domain.Entities;

namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    public interface IBookReservationRepository
    {
        /// <summary>
        /// Adds a new book reservation to the repository asynchronously.
        /// </summary>
        /// <param name="bookReservation">The book reservation to be added.</param>
        /// <returns>Reservation Id.</returns>
        Task<long> AddBookReservationAsync(BookReservation bookReservation, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a book reservation exists based on the reservation ID and book type ID.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation.</param>
        /// <param name="bookTypeId">The ID of the book type.</param>
        /// <returns>True if the book reservation exists, false otherwise.</returns>
        Task<bool> CheckIfBookReservationExists(long reservationId, long bookTypeId, CancellationToken cancellationToken);
    }
}
