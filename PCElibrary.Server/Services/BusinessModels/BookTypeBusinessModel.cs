namespace PCElibrary.Server.Services.BusinessModels
{
    using PCElibrary.Server.Enums;

    public class BookTypeBusinessModel
    {
        public BookTypeBusinessModel(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }

        public BookFormat Format { get; set; }

        public BookBusinessModel Book { get; set; } = null!;

        public IEnumerable<BookReservationBusinessModel> BookReservations { get; set; } = new List<BookReservationBusinessModel>();
    }
}
