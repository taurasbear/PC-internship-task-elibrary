namespace PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation
{
    using FluentValidation;
    using PCElibrary.Domain.Constants;

    public sealed class AddBookReservationValidator : AbstractValidator<AddBookReservationRequest>
    {
        public AddBookReservationValidator()
        {
            RuleFor(bookReservation => bookReservation.reservationId).GreaterThanOrEqualTo(ValidationConstants.MinId);
            RuleFor(bookReservation => bookReservation.bookTypeId).NotEmpty().GreaterThanOrEqualTo(ValidationConstants.MinId);
            RuleFor(bookReservation => bookReservation.quickPickUp).NotEmpty();
            RuleFor(bookReservation => bookReservation.days).NotEmpty().InclusiveBetween(ValidationConstants.MinDays, ValidationConstants.MaxDays);
        }
    }
}
