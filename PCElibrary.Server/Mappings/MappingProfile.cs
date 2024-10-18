namespace PCElibrary.Server.Mappings
{
    using AutoMapper;
    using PCElibrary.Server.Controllers.DTOs;
    using PCElibrary.Server.Repositories.Entities;
    using PCElibrary.Server.Services.BusinessModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity <-> BusinessModel
            this.CreateMap<Book, BookBusinessModel>()
                .ConstructUsing(b => new BookBusinessModel(b.Id))
                .ReverseMap();

            this.CreateMap<BookType, BookTypeBusinessModel>()
                .ConstructUsing(bt => new BookTypeBusinessModel(bt.Id))
                .ReverseMap();

            this.CreateMap<Reservation, ReservationBusinessModel>()
                .ConstructUsing(r => new ReservationBusinessModel(r.Id))
                .ReverseMap();

            this.CreateMap<BookReservation, BookReservationBusinessModel>()
                .ConstructUsing((br, context) => new BookReservationBusinessModel(
                    context.Mapper.Map<ReservationBusinessModel>(br.Reservation),
                    context.Mapper.Map<BookTypeBusinessModel>(br.BookType)))
                .ReverseMap();

            // BusinessModel <-> DTO
            this.CreateMap<BookBusinessModel, BookDTO>()
                .ReverseMap();

            //this.CreateMap<BookTypeBusinessModel, BookTypeDTO>
        }
    }
}
