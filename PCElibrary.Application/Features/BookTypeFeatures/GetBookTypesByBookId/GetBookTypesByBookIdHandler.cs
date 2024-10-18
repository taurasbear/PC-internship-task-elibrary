namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    using AutoMapper;
    using MediatR;
    using PCElibrary.Application.Interfaces;

    //TODO: Create base handler class
    public class GetBookTypesByBookIdHandler : IRequestHandler<GetBookTypesByBookIdRequest, IList<GetBookTypesByBookIdResponse>>
    {
        private readonly IBookTypeRepository bookTypeRepository;

        private readonly IMapper mapper;

        public GetBookTypesByBookIdHandler(IBookTypeRepository bookRepository, IMapper mapper)
        {
            this.bookTypeRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<IList<GetBookTypesByBookIdResponse>> Handle(GetBookTypesByBookIdRequest request, CancellationToken cancellationToken)
        {
            var bookTypes = await this.bookTypeRepository.GetBookTypesByBookId(request.bookId);
            return this.mapper.Map<IList<GetBookTypesByBookIdResponse>>(bookTypes);
        }
    }
}
