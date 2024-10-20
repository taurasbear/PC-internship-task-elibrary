namespace PCElibrary.Server.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using PCElibrary.Application.Features.ReservationFeatures.GetReservationDetailsById;

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{reservationId:long}")]
        public async Task<ActionResult<GetReservationDetailsByIdResponse>> GetReservationDetailsById(long reservationId, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(new GetReservationDetailsByIdRequest(reservationId), cancellationToken);
            return this.Ok(response);
        }
    }
}
