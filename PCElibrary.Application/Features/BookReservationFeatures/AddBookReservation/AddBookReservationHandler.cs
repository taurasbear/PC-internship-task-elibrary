namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using AutoMapper;
    using PCElibrary.Application.Interfaces.Data;

    public sealed class AddBookReservationHandler : BaseHandler<AddBookReservationRequest, AddBookReservationResponse>
    {
        public AddBookReservationHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task<AddBookReservationResponse> Handle(AddBookReservationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
