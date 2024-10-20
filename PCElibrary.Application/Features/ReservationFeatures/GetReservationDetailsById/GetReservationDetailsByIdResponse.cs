namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    public sealed record GetReservationDetailsByIdResponse
    {
        public long ReservationId { get; set; }

        public decimal TotalPrice { get; set; }

        public IList<BookReservationResponse> BookReservations { get; } = new List<BookReservationResponse>();

        public sealed record BookReservationResponse
        {
            public long BookTypeId { get; set; }

            public bool QuickPickUp { get; set; }

            public int Days { get; set; }

            public decimal Price { get; set; }
        }
    }
}
