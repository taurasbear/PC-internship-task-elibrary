namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    using AutoMapper;
    using MediatR;
    using PCElibrary.Server.Repositories.Interfaces;

    public sealed class GetAllBooksHandler : IRequestHandler<GetAllBooksRequest, IList<GetAllBooksResponse>>
    {
        private readonly IBookRepository bookRepository;

        private readonly IMapper mapper;

        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await this.bookRepository.GetAllBooksAsync(request.title, request.year, request.type);
            return this.mapper.Map<IList<GetAllBooksResponse>>(books);
        }
    }
}
