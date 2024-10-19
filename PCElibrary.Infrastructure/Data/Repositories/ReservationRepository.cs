namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Application.Interfaces.Data.Repositories;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(LibraryContext context) : base(context)
        {
        }
    }
}
