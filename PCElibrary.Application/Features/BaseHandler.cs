namespace PCElibrary.Application.Features
{
    using AutoMapper;
    using MediatR;
    using PCElibrary.Application.Interfaces.Data;

    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IUnitOfWork unitOfWork;

        protected readonly IMapper mapper;

        protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
