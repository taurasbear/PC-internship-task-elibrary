namespace PCElibrary.Server.Services.BusinessModels
{
    public class ReservationBusinessModel
    {
        public ReservationBusinessModel(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }

        public decimal TotalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public IEnumerable<BookReservationBusinessModel> BookReservations { get; set; } = new List<BookReservationBusinessModel>();
    }
}
