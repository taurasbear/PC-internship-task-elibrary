namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using AutoMapper;
    using PCElibrary.Domain.Entities;

    public sealed class AddBookReservationMapper : Profile
    {
        public AddBookReservationMapper()
        {
            this.CreateMap<AddBookReservationRequest, BookReservation>();
            this.CreateMap<BookReservation, AddBookReservationResponse>();
        }
    }
}
