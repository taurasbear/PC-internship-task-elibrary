﻿namespace PCElibrary.Application.Features.BookFeatures.GetAllBooks
{
    using AutoMapper;
    using PCElibrary.Application.Interfaces;

    public sealed class GetAllBooksHandler : BaseHandler<GetAllBooksRequest, IList<GetAllBooksResponse>>
    {
        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<IList<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await this.unitOfWork.BookRepository.GetAllBooksAsync(request.title, request.year, request.type);
            return this.mapper.Map<IList<GetAllBooksResponse>>(books);
        }
    }
}
