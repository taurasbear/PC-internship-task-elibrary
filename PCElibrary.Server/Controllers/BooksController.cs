using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCElibrary.Application.Features.BookFeatures.GetAllBooks;
using PCElibrary.Domain.Enums;

namespace PCElibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<GetAllBooksResponse>>> GetBooks(
            [FromQuery] string? title,
            [FromQuery] int? year,
            [FromQuery] BookFormat? type,
            CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(new GetAllBooksRequest(title, year, type), cancellationToken);
            return this.Ok(response);
        }
    }
}
