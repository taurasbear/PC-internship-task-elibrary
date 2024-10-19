namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Application.Interfaces;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(LibraryContext context) : base(context)
        {
        }
    }
}
