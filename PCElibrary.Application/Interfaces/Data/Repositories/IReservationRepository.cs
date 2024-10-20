namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    using PCElibrary.Domain.Entities;

    public interface IReservationRepository
    {
        /// <summary>
        /// Retrieves a reservation with its book reservations by its ID.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation.</param>
        /// <returns>The reservation with its book reservations with the specified ID.</returns>
        Task<Reservation> GetReservationDetailsByIdAsync(long reservationId, CancellationToken cancellationToken);
    }
}
