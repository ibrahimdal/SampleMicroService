using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SampleMicroService.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DemoController(
            IHttpContextAccessor httpContextAccessor
            )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Demo değerleri döner
        /// </summary>
        /// <returns>Dizi döner</returns>
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetList()
        {
            return Ok(new string[] { "item1", "item2", "item3" });
        }

        /// <summary>
        /// Tek bir demo değeri döner
        /// </summary>
        /// <param name="id">demo değer id</param>
        /// <returns>demo değeri</returns>
        [HttpGet]
        [Route("Single/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok("item" + id);
        }
    }
}
