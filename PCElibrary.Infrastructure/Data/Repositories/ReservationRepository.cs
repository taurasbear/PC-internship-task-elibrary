namespace PCElibrary.Infrastructure.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Application.Interfaces.Data.Repositories;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Infrastructure.Data.DbContext;
    using System.Threading.Tasks;

    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<Reservation> GetReservationDetailsByIdAsync(long reservationId, CancellationToken cancellationToken)
        {
            return await this.libraryContext.Reservations
                .Include(reservation => reservation.BookReservations)
                .ThenInclude(bookReservation => bookReservation.BookType)
                .ThenInclude(bookType => bookType.Book)
                .FirstOrDefaultAsync(reservation => reservation.Id == reservationId, cancellationToken);
        }
    }
}
