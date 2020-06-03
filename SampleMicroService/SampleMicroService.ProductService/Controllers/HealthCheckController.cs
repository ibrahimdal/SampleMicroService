using Microsoft.AspNetCore.Mvc;

namespace SampleMicroService.ProductService.Controllers
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
