namespace PCElibrary.Domain.Entities
{
    using System.Collections.ObjectModel;

    public class Reservation
    {
        public long Id { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public ICollection<BookReservation> BookReservations { get; set; } = new Collection<BookReservation>();
    }
}
