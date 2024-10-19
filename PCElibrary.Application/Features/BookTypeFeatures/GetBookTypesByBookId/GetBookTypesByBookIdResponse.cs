namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    public sealed record GetBookTypesByBookIdResponse
    {
        public long Id { get; set; }

        public string BookType { get; set; } = string.Empty;
    }
}
