namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    using AutoMapper;
    using PCElibrary.Domain.Entities;

    public class GetReservationDetailsByIdMapper : Profile
    {
        public GetReservationDetailsByIdMapper()
        {
            this.CreateMap<Reservation, GetReservationDetailsByIdResponse>();
        }
    }
}
