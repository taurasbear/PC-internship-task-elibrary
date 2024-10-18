using AutoMapper;
using PCElibrary.Server.Controllers.DTOs;
using PCElibrary.Server.Repositories.Interfaces;
using PCElibrary.Server.Services.BusinessModels;
using PCElibrary.Server.Services.Interfaces;

namespace PCElibrary.Server.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            IEnumerable<BookBusinessModel> books = await this.bookRepository.GetAllBooksAsync();

            return this.mapper.Map<IEnumerable<BookDTO>>(books);
        }
    }
}
