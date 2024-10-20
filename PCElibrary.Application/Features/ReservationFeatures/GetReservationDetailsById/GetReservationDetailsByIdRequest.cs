namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    using MediatR;

    public sealed record GetReservationDetailsByIdRequest(long reservationId) : IRequest<GetReservationDetailsByIdResponse>;
}
