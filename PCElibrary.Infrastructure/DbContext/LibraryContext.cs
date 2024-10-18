namespace PCElibrary.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using PCElibrary.Domain.Entities;

    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookReservation> BookReservations { get; set; }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("LibraryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookReservation>()
                .HasKey(br => new { br.ReservationId, br.BookTypeId });

            modelBuilder.Entity<BookReservation>()
                .HasOne(br => br.Reservation)
                .WithMany(r => r.BookReservations)
                .HasForeignKey(br => br.ReservationId);

            modelBuilder.Entity<BookReservation>()
                .HasOne(br => br.BookType)
                .WithMany(bt => bt.BookReservations)
                .HasForeignKey(br => br.BookTypeId);

            modelBuilder.Entity<BookType>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTypes)
                .HasForeignKey(bt => bt.BookId);

            modelBuilder.Seed();
        }
    }
}
