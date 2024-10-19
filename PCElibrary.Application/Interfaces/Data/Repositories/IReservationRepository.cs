namespace PCElibrary.Application.Interfaces.Data.Repositories
{
    using PCElibrary.Domain.Entities;

    public interface IReservationRepository
    {
        /// <summary>
        /// Retrieves a reservation by its ID.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation.</param>
        /// <returns>The reservation with the specified ID.</returns>
        Task<Reservation> GetReservationByIdAsync(long reservationId, CancellationToken cancellationToken);
    }
}
