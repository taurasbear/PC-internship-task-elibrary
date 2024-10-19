namespace PCElibrary.Infrastructure.Data.Repositories
{
    using PCElibrary.Infrastructure.Data.DbContext;

    public class BaseRepository
    {
        protected readonly LibraryContext libraryContext;

        public BaseRepository(LibraryContext context)
        {
            libraryContext = context;
        }
    }
}
