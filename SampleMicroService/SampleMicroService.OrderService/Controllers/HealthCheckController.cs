using Microsoft.AspNetCore.Mvc;

namespace SampleMicroService.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("")]
        [HttpHead("")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
