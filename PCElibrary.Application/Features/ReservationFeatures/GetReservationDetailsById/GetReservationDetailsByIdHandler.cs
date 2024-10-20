namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    using AutoMapper;
    using PCElibrary.Application.Common.Exceptions;
    using PCElibrary.Application.Interfaces.Data;

    public class GetReservationDetailsByIdHandler : BaseHandler<GetReservationDetailsByIdRequest, GetReservationDetailsByIdResponse>
    {
        public GetReservationDetailsByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public override async Task<GetReservationDetailsByIdResponse> Handle(GetReservationDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var reservation = await this.unitOfWork.ReservationRepository.GetReservationDetailsByIdAsync(request.reservationId, cancellationToken);
            if (reservation == null)
            {
                throw new BadRequestException("Reservation with specified ID doesn't exist.");
            }
            return this.mapper.Map<GetReservationDetailsByIdResponse>(reservation);
        }
    }
}
