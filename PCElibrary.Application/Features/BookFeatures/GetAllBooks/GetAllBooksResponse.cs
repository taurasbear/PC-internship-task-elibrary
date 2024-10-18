namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    public sealed record GetAllBooksResponse
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public string ImagePath { get; set; } = string.Empty;
    }
}
