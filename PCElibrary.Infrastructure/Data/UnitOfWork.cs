using PCElibrary.Application.Interfaces;
using PCElibrary.Infrastructure.Data.DbContext;
using PCElibrary.Infrastructure.Data.Repositories;
using PCElibrary.Server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCElibrary.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LibraryContext libraryContext;

        private IBookRepository bookRepository;

        private IBookTypeRepository bookTypeRepository;

        private IBookReservationRepository bookReservationRepository;

        private IReservationRepository reservationRepository;

        private bool disposed;

        public UnitOfWork(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public IBookRepository BookRepository
        {
            get
            {
                return bookRepository ??= new BookRepository(libraryContext);
            }
        }

        public IBookTypeRepository BookTypeRepository
        {
            get
            {
                return bookTypeRepository ??= new BookTypeRepository(libraryContext);
            }
        }

        public IBookReservationRepository BookReservationRepository
        {
            get
            {
                return bookReservationRepository ??= new BookReservationRepository(libraryContext);
            }
        }

        public IReservationRepository ReservationRepository
        {
            get
            {
                return reservationRepository ??= new ReservationRepository(libraryContext);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                libraryContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await this.libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
