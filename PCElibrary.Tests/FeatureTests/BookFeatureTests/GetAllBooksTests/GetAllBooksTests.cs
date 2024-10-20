using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using PCElibrary.Application.Features.BookFeatures.GetAllBooks;
using PCElibrary.Application.Interfaces.Data;
using PCElibrary.Domain.Entities;
using PCElibrary.Domain.Enums;
using Xunit;

namespace PCElibrary.Tests.FeatureTests.BookFeatureTests.GetAllBooksTests
{
    public class GetAllBooksTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllBooksHandler _handler;

        public GetAllBooksTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllBooksHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBooks_WhenBooksExist()
        {
            // Arrange
            var books = new List<Book> { new Book { Title = "Test Book1" }, new Book { Title = "Test Book2" } };
            var bookResponses = new List<GetAllBooksResponse> { new GetAllBooksResponse { Title = "Test Book1" }, new GetAllBooksResponse { Title = "Test Book2" } };

            _unitOfWorkMock.Setup(u => u.BookRepository.GetAllBooksAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<BookFormat?>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(books);

            _mapperMock.Setup(m => m.Map<IList<GetAllBooksResponse>>(books)).Returns(bookResponses);

            var request = new GetAllBooksRequest(string.Empty, null, null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Book1", result[0].Title);
            Assert.Equal("Test Book2", result[1].Title);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoBooksExist()
        {
            // Arrange
            var books = new List<Book>();
            var bookResponses = new List<GetAllBooksResponse>();

            _unitOfWorkMock.Setup(u => u.BookRepository.GetAllBooksAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<BookFormat?>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(books);
            _mapperMock.Setup(m => m.Map<IList<GetAllBooksResponse>>(books)).Returns(bookResponses);

            var request = new GetAllBooksRequest(string.Empty, null, null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.BookRepository.GetAllBooksAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<BookFormat?>(), It.IsAny<CancellationToken>()))
                           .ThrowsAsync(new Exception("Database error"));

            var request = new GetAllBooksRequest(string.Empty, null, null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}