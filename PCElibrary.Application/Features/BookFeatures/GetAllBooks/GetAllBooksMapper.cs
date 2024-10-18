namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    using AutoMapper;
    using PCElibrary.Domain.Entities;

    public sealed class GetAllBooksMapper : Profile
    {
        public GetAllBooksMapper()
        {
            this.CreateMap<Book, GetAllBooksResponse>();
        }
    }
}
