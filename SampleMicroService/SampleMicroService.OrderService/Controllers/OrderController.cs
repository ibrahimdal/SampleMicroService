using Microsoft.AspNetCore.Mvc;
using SampleMicroService.Application.Order.Commands.CreateOrder;
using SampleMicroService.Application.Order.Queries.GetOrder;
using System.Threading.Tasks;

namespace SampleMicroService.OrderService.Controllers
{
    public class OrderController : ApiController
    {
        /// <summary>
        /// id ye göre order bilgisi döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderResult>> Get(int id)
        {
            return await Mediator.Send(new GetOrderQuery { orderId = id });
        }

        /// <summary>
        /// Yeni bir sipariş oluşturur.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
