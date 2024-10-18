namespace PCElibrary.Server.Services.BusinessModels
{
    public class BookBusinessModel
    {
        public BookBusinessModel(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public IEnumerable<BookTypeBusinessModel> BookTypes { get; set; } = new List<BookTypeBusinessModel>();
    }
}
