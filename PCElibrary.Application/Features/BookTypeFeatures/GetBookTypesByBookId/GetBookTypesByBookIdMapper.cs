namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    using AutoMapper;
    using PCElibrary.Domain.Entities;

    public class GetBookTypesByBookIdMapper : Profile
    {
        public GetBookTypesByBookIdMapper()
        {
            this.CreateMap<BookType, GetBookTypesByBookIdResponse>()
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(src => src.Format.ToString()));
        }
    }
}
