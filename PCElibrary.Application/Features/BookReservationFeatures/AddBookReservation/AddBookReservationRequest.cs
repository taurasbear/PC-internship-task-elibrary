namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using MediatR;

    public sealed record AddBookReservationRequest(long? reservationId, long bookTypeId, bool quickPickUp, int days) : IRequest<AddBookReservationResponse>;
}
