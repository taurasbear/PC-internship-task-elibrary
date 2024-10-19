namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    using AutoMapper;
    using MediatR;
    using PCElibrary.Application.Interfaces;

    public sealed class GetAllBooksHandler : IRequestHandler<GetAllBooksRequest, IList<GetAllBooksResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await this.unitOfWork.BookRepository.GetAllBooksAsync(request.title, request.year, request.type);
            return this.mapper.Map<IList<GetAllBooksResponse>>(books);
        }
    }
}
