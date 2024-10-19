namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Application.Interfaces.Data.Repositories;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Infrastructure.Data.DbContext;

    public class BookReservationRepository : BaseRepository, IBookReservationRepository
    {
        public BookReservationRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<long> AddBookReservationAsync(BookReservation bookReservation)
        {
            var addedBookReservation = await this.libraryContext.BookReservations.AddAsync(bookReservation);
            return addedBookReservation.Entity.ReservationId;
        }
    }
}
