using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCElibrary.Application.Features.BookReservationFeatures.AddBookReservation;

namespace PCElibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReservationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AddBookReservationResponse>> AddBookReservation(
            [FromBody] AddBookReservationRequest bookReservationRequest,
            CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(bookReservationRequest, cancellationToken);
            return this.Ok(response);
        }
    }
}
