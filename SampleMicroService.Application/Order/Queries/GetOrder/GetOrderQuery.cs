using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMicroService.Application.Order.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<GetOrderResult>
    {
        public int orderId { get; set; }
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, GetOrderResult>
    {
        public async Task<GetOrderResult> Handle(
            GetOrderQuery request,
            CancellationToken cancellationToken
            )
        {
            return new GetOrderResult
            {
                code = "ORDERCODE",
                createdDate = DateTime.UtcNow,
                id = request.orderId,
                totalAmount = 19.99M
            };
        }
    }
}
