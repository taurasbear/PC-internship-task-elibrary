namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Application.Interfaces;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class BookReservationRepository : BaseRepository, IBookReservationRepository
    {
        public BookReservationRepository(LibraryContext context) : base(context)
        {
        }
    }
}
