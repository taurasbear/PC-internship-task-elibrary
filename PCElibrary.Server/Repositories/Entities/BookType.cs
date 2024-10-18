namespace PCElibrary.Server.Repositories.Entities
{
    using System.Collections.ObjectModel;
    using PCElibrary.Server.Enums;

    public class BookType
    {
        public long Id { get; set; }

        public BookFormat Format { get; set; }

        public long BookId { get; set; }

        public Book Book { get; set; } = null!;

        public ICollection<BookReservation> BookReservations { get; set; } = new Collection<BookReservation>();
    }
}
