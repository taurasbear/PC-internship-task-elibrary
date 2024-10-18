namespace PCElibrary.Server.Repositories
{
    using AutoMapper;
    using Microsoft.AspNetCore.Components.Forms.Mapping;
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Server.DbContext;
    using PCElibrary.Server.Repositories.Entities;
    using PCElibrary.Server.Repositories.Interfaces;
    using PCElibrary.Server.Services.BusinessModels;

    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;

        public BookRepository(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookBusinessModel>> GetAllBooksAsync()
        {
            IEnumerable<Book> books = await this.libraryContext.Books.ToListAsync();

            return this.mapper.Map<IEnumerable<BookBusinessModel>>(books);
        }
    }
}
