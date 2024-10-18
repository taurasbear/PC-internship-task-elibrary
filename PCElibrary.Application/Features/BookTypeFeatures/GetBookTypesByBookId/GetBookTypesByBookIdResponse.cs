namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    public sealed record GetBookTypesByBookIdResponse
    {
        public string BookType { get; set; } = string.Empty;
    }
}
