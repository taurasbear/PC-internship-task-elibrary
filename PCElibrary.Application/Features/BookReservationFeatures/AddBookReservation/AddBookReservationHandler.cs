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
            var bookReservation = mapper.Map<BookReservation>(request);
            bookReservation.BookType = await unitOfWork.BookTypeRepository.GetBookTypeByIdAsync(request.bookTypeId, cancellationToken);
            bookReservation.Price = ReservationCalculator.CalculatePrice(bookReservation);

            if (request.reservationId.HasValue)
            {
                var reservation = await unitOfWork.ReservationRepository.GetReservationByIdAsync(request.reservationId.Value, cancellationToken);
                if (reservation == null)
                {
                    throw new BadRequestException("Chosen reservation doesn't exist.");
                }
                if (reservation.BookReservations
                    .Any(bReservation => bReservation.ReservationId == bookReservation.ReservationId
                    && bReservation.BookTypeId == bookReservation.BookTypeId))
                {
                    throw new BadRequestException("Book reservation already exists.");
                }

                reservation.BookReservations.Add(bookReservation);
                reservation.UpdateTotalPrice();
            }
            else
            {
                var reservation = new Reservation();
                reservation.BookReservations.Add(bookReservation);
                reservation.UpdateTotalPrice();
                bookReservation.Reservation = reservation;

                //TODO: Fix this
                var reservationId = await unitOfWork.BookReservationRepository.AddBookReservationAsync(bookReservation, cancellationToken);
                Console.WriteLine($"---> reservationId: {reservationId}");
                Console.WriteLine($"---> bookReservation.ReservationId: {bookReservation.ReservationId}");
            }
            await unitOfWork.SaveAsync(cancellationToken);

            return mapper.Map<AddBookReservationResponse>(bookReservation);
        }
    }
}
