using AutoMapper;
using PCElibrary.Server.Controllers.DTOs;
using PCElibrary.Server.Enums;
using PCElibrary.Server.Mappings;
using PCElibrary.Server.Repositories.Entities;
using PCElibrary.Server.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCElibrary.Tests.Mappings
{
    public class MappingProfileTests
    {
        private readonly IMapper mapper;

        public MappingProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void Should_Map_Book_To_BookBusinessModel()
        {
            // Arrange
            Book book = new Book
            {
                Id = 1,
                Title = "Dune Messiah",
                Year = 1969,
                ImagePath = "Test/Test.png",
                BookTypes = new List<BookType>
                    {
                        new BookType()
                        {
                            Id = 1,
                            Format = BookFormat.Physical,
                            BookId = 1,
                            BookReservations = new List<BookReservation>()
                            {
                                new BookReservation
                                {
                                    ReservationId = 1,
                                    BookTypeId = 1,
                                    QuickPickUp = false,
                                    Days = 20,
                                },

                                new BookReservation
                                {
                                    ReservationId = 2,
                                    BookTypeId = 1,
                                    QuickPickUp = true,
                                    Days = 10,
                                },
                            }
                        },

                        new BookType()
                        {
                            Id = 2,
                            Format = BookFormat.Audio,
                            BookId = 1,
                            BookReservations = new List<BookReservation>()
                            {
                                new BookReservation
                                {
                                    ReservationId = 3,
                                    BookTypeId = 2,
                                    QuickPickUp = false,
                                    Days = 5,
                                },

                                new BookReservation
                                {
                                    ReservationId = 4,
                                    BookTypeId = 2,
                                    QuickPickUp = true,
                                    Days = 15,
                                },
                            }
                        },
                    }
            };

            foreach (var bt in book.BookTypes)
            {
                bt.Book = book;
                foreach (var br in bt.BookReservations)
                {
                    br.BookType = bt;
                }
            }

            // Act
            var bookBusinessModel = this.mapper.Map<BookBusinessModel>(book);

            // Assert
            Assert.Equal(book.Id, bookBusinessModel.Id);
            Assert.Equal(book.Title, bookBusinessModel.Title);
            Assert.Equal(book.Year, bookBusinessModel.Year);
            Assert.Equal(book.ImagePath, bookBusinessModel.ImagePath);

            var bookTypes = book.BookTypes.ToList();
            var bookTypesBusinessModel = bookBusinessModel.BookTypes.ToList();
            for (int i = 0; i < bookTypes.Count; i++)
            {
                Assert.Equal(bookTypes[i].Id, bookTypesBusinessModel[i].Id);
                Assert.Equal(bookTypes[i].Format, bookTypesBusinessModel[i].Format);
                Assert.Equal(bookTypes[i].Book.Id, bookTypesBusinessModel[i].Book.Id);

                var bookReservations = bookTypes[i].BookReservations.ToList();
                var bookReservationsBusinessModel = bookTypesBusinessModel[i].BookReservations.ToList();
                for (int j = 0; j < bookReservations.Count; j++)
                {
                    Assert.Equal(bookReservations[j].QuickPickUp, bookReservationsBusinessModel[j].QuickPickUp);
                    Assert.Equal(bookReservations[j].Days, bookReservationsBusinessModel[j].Days);
                    Assert.Equal(bookReservations[j].BookType.Id, bookReservationsBusinessModel[j].BookType.Id);
                }
            }
        }

        [Fact]
        public void Should_ReverseMap_BookBusinessModel_To_Book()
        {
            // Arrange
            BookBusinessModel bookBusinessModel = new BookBusinessModel(1)
            {
                Title = "Dune Messiah",
                Year = 1969,
                ImagePath = "Test/Test.png",
                BookTypes = new List<BookTypeBusinessModel>
                    {
                        new BookTypeBusinessModel(1)
                        {
                            Format = BookFormat.Physical,
                        },

                        new BookTypeBusinessModel(2)
                        {
                            Format = BookFormat.Audio,
                        },
                    }
            };

            foreach (var bt in bookBusinessModel.BookTypes)
            {
                bt.Book = bookBusinessModel;
                var bookReservationsBusinessModel = bt.BookReservations.ToList();
                bookReservationsBusinessModel.Add(
                    new BookReservationBusinessModel(
                            new ReservationBusinessModel(1),
                            new BookTypeBusinessModel(bt.Id)
                            {
                                Format = bt.Format,
                                Book = bt.Book,
                            }
                        )
                    {
                        QuickPickUp = false,
                        Days = 20,
                    }
                    );
                bookReservationsBusinessModel.Add(
                    new BookReservationBusinessModel(
                            new ReservationBusinessModel(1),
                            new BookTypeBusinessModel(bt.Id)
                            {
                                Format = bt.Format,
                                Book = bt.Book,
                            }
                        )
                    {
                        QuickPickUp = false,
                        Days = 10,
                    }
                    );
            }

            // Act
            var book = this.mapper.Map<Book>(bookBusinessModel);

            // Assert
            Assert.Equal(bookBusinessModel.Id, book.Id);
            Assert.Equal(bookBusinessModel.Title, book.Title);
            Assert.Equal(bookBusinessModel.Year, book.Year);
            Assert.Equal(bookBusinessModel.ImagePath, book.ImagePath);

            var bookTypesBusinessModel = bookBusinessModel.BookTypes.ToList();
            var bookTypes = book.BookTypes.ToList();
            for (int i = 0; i < bookTypesBusinessModel.Count; i++)
            {
                Assert.Equal(bookTypesBusinessModel[i].Id, bookTypes[i].Id);
                Assert.Equal(bookTypesBusinessModel[i].Format, bookTypes[i].Format);
                Assert.Equal(bookTypesBusinessModel[i].Book.Id, bookTypes[i].Book.Id);

                var bookReservationsBusinessModel = bookTypesBusinessModel[i].BookReservations.ToList();
                var bookReservations = bookTypes[i].BookReservations.ToList();
                for (int j = 0; j < bookReservationsBusinessModel.Count; j++)
                {
                    Assert.Equal(bookReservationsBusinessModel[j].QuickPickUp, bookReservations[j].QuickPickUp);
                    Assert.Equal(bookReservationsBusinessModel[j].Days, bookReservations[j].Days);
                    Assert.Equal(bookReservationsBusinessModel[j].BookType.Id, bookReservations[j].BookType.Id);
                    Assert.Equal(bookReservationsBusinessModel[j].Reservation.Id, bookReservations[j].Reservation.Id);
                }
            }
        }

        [Fact]
        public void Should_Map_BookBusinessModel_To_BookDTO()
        {
            // Arrange
            BookBusinessModel bookBusinessModel = new BookBusinessModel(1)
            {
                Title = "Dune Messiah",
                Year = 1969,
                ImagePath = "Test/test.png",
            };

            // Act
            var bookDTO = this.mapper.Map<BookDTO>(bookBusinessModel);

            // Assert
            Assert.Equal(bookBusinessModel.Id, bookDTO.Id);
            Assert.Equal(bookBusinessModel.Title, bookDTO.Title);
            Assert.Equal(bookBusinessModel.Year, bookDTO.Year);
            Assert.Equal(bookBusinessModel.ImagePath, bookDTO.ImagePath);
        }

        [Fact]
        public void Should_ReverseMap_BookDTO_To_BookBusinessModel()
        {
            // Arrange
            BookDTO bookDTO = new BookDTO
            {
                Id = 1,
                Title = "Dune Messiah",
                Year = 1969,
                ImagePath = "Test/test.png",
            };

            // Act
            var bookBusinessModel = this.mapper.Map<BookBusinessModel>(bookDTO);

            // Assert
            Assert.Equal(bookDTO.Id, bookBusinessModel.Id);
            Assert.Equal(bookDTO.Title, bookBusinessModel.Title);
            Assert.Equal(bookDTO.Year, bookBusinessModel.Year);
            Assert.Equal(bookDTO.ImagePath, bookBusinessModel.ImagePath);
        }
    }
}
