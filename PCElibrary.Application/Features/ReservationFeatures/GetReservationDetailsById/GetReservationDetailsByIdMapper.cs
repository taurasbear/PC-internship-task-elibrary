namespace PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById
{
    using AutoMapper;
    using PCElibrary.Domain.Entities;

    public class GetReservationDetailsByIdMapper : Profile
    {
        public GetReservationDetailsByIdMapper()
        {
            this.CreateMap<Reservation, GetReservationDetailsByIdResponse>()
                .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.Id));

            this.CreateMap<BookReservation, GetReservationDetailsByIdResponse.BookReservationResponse>()
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(src => src.BookType.Format.ToString()))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.BookType.Book.ImagePath));
        }
    }
}
