namespace PCElibrary.Server.Services.BusinessModels
{
    public class BookReservationBusinessModel
    {
        public BookReservationBusinessModel(ReservationBusinessModel reservation, BookTypeBusinessModel bookType)
        {
            this.Reservation = reservation;
            this.BookType = bookType;
        }

        public ReservationBusinessModel Reservation { get; private set; }

        public BookTypeBusinessModel BookType { get; private set; }

        public bool QuickPickUp { get; set; }

        public int Days { get; set; }
    }
}
