namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using FluentValidation;

    public sealed class AddBookReservationValidator : AbstractValidator<AddBookReservationRequest>
    {
        public AddBookReservationValidator()
        {
            RuleFor(bookReservation => bookReservation.reservationId).NotEmpty();
            RuleFor(bookReservation => bookReservation.bookTypeId).NotEmpty();
            RuleFor(bookReservation => bookReservation.quickPickUp).NotEmpty();
            RuleFor(bookReservation => bookReservation.days).NotEmpty();
        }
    }
}
