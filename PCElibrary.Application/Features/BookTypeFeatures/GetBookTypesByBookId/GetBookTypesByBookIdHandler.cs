namespace PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId
{
    using AutoMapper;
    using PCElibrary.Application.Interfaces.Data;

    public class GetBookTypesByBookIdHandler : BaseHandler<GetBookTypesByBookIdRequest, IList<GetBookTypesByBookIdResponse>>
    {
        public GetBookTypesByBookIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<IList<GetBookTypesByBookIdResponse>> Handle(GetBookTypesByBookIdRequest request, CancellationToken cancellationToken)
        {
            var bookTypes = await this.unitOfWork.BookTypeRepository.GetBookTypesByBookId(request.bookId, cancellationToken);
            return this.mapper.Map<IList<GetBookTypesByBookIdResponse>>(bookTypes);
        }
    }
}
