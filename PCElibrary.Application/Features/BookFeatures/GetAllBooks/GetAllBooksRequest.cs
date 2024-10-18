namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    using MediatR;
    using PCElibrary.Domain.Enums;

    public sealed record class GetAllBooksRequest(string title, int? year, BookFormat? type) : IRequest<IList<GetAllBooksResponse>>;
}
