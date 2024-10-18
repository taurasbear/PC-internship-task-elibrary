namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    using MediatR;

    public sealed record GetBookTypesByBookIdRequest(long bookId) : IRequest<IList<GetBookTypesByBookIdResponse>>;
}
