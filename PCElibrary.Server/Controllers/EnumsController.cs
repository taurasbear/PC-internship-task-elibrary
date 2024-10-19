namespace PCElibrary.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PCElibrary.Domain.Enums;

    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        public EnumsController()
        {
        }

        [HttpGet("booktypes")]
        public ActionResult<IList<string>> GetEnums()
        {
            var formats = Enum.GetNames(typeof(BookFormat)).ToList();
            return this.Ok(formats);
        }
    }
}
