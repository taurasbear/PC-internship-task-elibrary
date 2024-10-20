namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    using PCElibrary.Domain.Enums;

    public sealed record GetReservationDetailsByIdResponse
    {
        public long ReservationId { get; set; }

        public decimal TotalPrice { get; set; }

        public IList<BookReservationResponse> BookReservations { get; } = new List<BookReservationResponse>();

        public sealed record BookReservationResponse
        {
            public string BookType { get; set; } = string.Empty;

            public string ImagePath { get; set; } = string.Empty;

            public bool QuickPickUp { get; set; }

            public int Days { get; set; }

            public decimal Price { get; set; }
        }
    }
}
