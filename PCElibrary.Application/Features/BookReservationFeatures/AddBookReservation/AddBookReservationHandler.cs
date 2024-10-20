namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using AutoMapper;
    using PCElibrary.Application.Common.Exceptions;
    using PCElibrary.Application.Interfaces.Data;
    using PCElibrary.Domain.Entities;
    using PCElibrary.Domain.Services;

    public sealed class AddBookReservationHandler : BaseHandler<AddBookReservationRequest, AddBookReservationResponse>
    {
        public AddBookReservationHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<AddBookReservationResponse> Handle(AddBookReservationRequest request, CancellationToken cancellationToken)
        {
            var bookReservation = await CreateBookReservation(request, cancellationToken);

            if (request.reservationId.HasValue)
            {
                await UpdateExistingReservationAsync(request.reservationId.Value, bookReservation, cancellationToken);
            }
            else
            {
                await CreateNewReservationAsync(bookReservation, cancellationToken);
            }

            await this.unitOfWork.SaveAsync(cancellationToken);

            return mapper.Map<AddBookReservationResponse>(bookReservation);
        }

        private async Task<BookReservation> CreateBookReservation(AddBookReservationRequest request, CancellationToken cancellationToken)
        {
            if (request.reservationId.HasValue &&
                await this.unitOfWork.BookReservationRepository
                .CheckIfBookReservationExists(request.reservationId.Value, request.bookTypeId, cancellationToken))
            {
                throw new BadRequestException("Book reservation already exists.");
            }
            var bookReservation = mapper.Map<BookReservation>(request);
            bookReservation.BookType = await this.unitOfWork.BookTypeRepository.GetBookTypeByIdAsync(request.bookTypeId, cancellationToken);
            bookReservation.Price = ReservationCalculator.CalculatePrice(bookReservation);
            return bookReservation;
        }

        private async Task UpdateExistingReservationAsync(long reservationId, BookReservation bookReservation, CancellationToken cancellationToken)
        {
            var reservation = await this.unitOfWork.ReservationRepository.GetReservationDetailsByIdAsync(reservationId, cancellationToken);
            if (reservation == null)
            {
                throw new BadRequestException("Chosen reservation doesn't exist.");
            }

            reservation.BookReservations.Add(bookReservation);
            reservation.UpdateTotalPrice();
        }

        private async Task CreateNewReservationAsync(BookReservation bookReservation, CancellationToken cancellationToken)
        {
            var reservation = new Reservation();
            reservation.BookReservations.Add(bookReservation);
            reservation.UpdateTotalPrice();

            bookReservation.Reservation = reservation;
            await this.unitOfWork.BookReservationRepository.AddBookReservationAsync(bookReservation, cancellationToken);
        }
    }
}
