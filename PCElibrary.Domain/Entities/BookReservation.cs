namespace PCElibrary.Domain.Entities
{
    public class BookReservation
    {
        public long ReservationId { get; set; }

        public Reservation Reservation { get; set; } = null!;

        public long BookTypeId { get; set; }

        public BookType BookType { get; set; } = null!;

        public bool QuickPickUp { get; set; }

        public int Days { get; set; }

        public decimal Price { get; set; }
    }
}
