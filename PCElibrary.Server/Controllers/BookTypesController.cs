namespace PCElibrary.Server.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using PCElibrary.Application.Features.BookTypeFeatures.GetBookTypesByBookId;

    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<GetBookTypesByBookIdResponse>>> GetBookTypesByBookId([FromQuery] long bookId, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(new GetBookTypesByBookIdRequest(bookId), cancellationToken);
            return this.Ok(response);
        }
    }
}
