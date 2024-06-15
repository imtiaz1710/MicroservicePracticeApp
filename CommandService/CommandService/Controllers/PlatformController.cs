using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        [HttpPost]
        public IActionResult TestInboundConnection(object data)
        {
            return Ok("Inbound test done");
        }
    }
}
