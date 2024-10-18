namespace PCElibrary.Domain.Entities
{
    using System.Collections.ObjectModel;

    public class Book
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public ICollection<BookType> BookTypes { get; set; } = new Collection<BookType>();
    }
}
