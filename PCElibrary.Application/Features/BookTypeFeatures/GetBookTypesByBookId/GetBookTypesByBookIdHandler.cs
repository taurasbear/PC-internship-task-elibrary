namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    using AutoMapper;
    using MediatR;
    using PCElibrary.Application.Interfaces;

    //TODO: Create base handler class
    public class GetBookTypesByBookIdHandler : IRequestHandler<GetBookTypesByBookIdRequest, IList<GetBookTypesByBookIdResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public GetBookTypesByBookIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetBookTypesByBookIdResponse>> Handle(GetBookTypesByBookIdRequest request, CancellationToken cancellationToken)
        {
            var bookTypes = await this.unitOfWork.BookTypeRepository.GetBookTypesByBookId(request.bookId);
            return this.mapper.Map<IList<GetBookTypesByBookIdResponse>>(bookTypes);
        }
    }
}
