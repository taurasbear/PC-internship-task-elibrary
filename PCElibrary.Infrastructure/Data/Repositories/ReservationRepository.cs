namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Application.Interfaces.Data.Repositories;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Infrastructure.Data.DbContext;
    using System.Threading.Tasks;

    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<Reservation> GetReservationByIdAsync(long reservationId, CancellationToken cancellationToken)
        {
            return await this.libraryContext.Reservations.FindAsync(reservationId, cancellationToken);
        }
    }
}
