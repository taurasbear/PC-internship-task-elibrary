using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCElibrary.Domain.Enums;

namespace PCElibrary.Server.Controllers
{
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
