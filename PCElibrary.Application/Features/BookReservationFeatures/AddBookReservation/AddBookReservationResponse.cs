namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    public sealed record AddBookReservationResponse
    {
        public long ReservationId { get; set; }

        public long BookReservationId { get; set; }
    }
}
