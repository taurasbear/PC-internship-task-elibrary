namespace PCElibrary.Application.Interfaces
{
    using PCElibrary.Server.Repositories.Interfaces;

    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        IBookTypeRepository BookTypeRepository { get; }

        IBookReservationRepository BookReservationRepository { get; }

        IReservationRepository ReservationRepository { get; }

        Task Save(CancellationToken cancellationToken);
    }
}
