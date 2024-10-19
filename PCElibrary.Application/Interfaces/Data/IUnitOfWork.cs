using PCElibrary.Application.Interfaces.Data.Repositories;

namespace PCElibrary.Application.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        IBookTypeRepository BookTypeRepository { get; }

        IBookReservationRepository BookReservationRepository { get; }

        IReservationRepository ReservationRepository { get; }

        Task Save(CancellationToken cancellationToken);
    }
}
