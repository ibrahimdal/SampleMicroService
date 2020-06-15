using MediatR;
using SampleMicroService.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMicroService.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public decimal totalAmount { get; set; }
        public string orderCode { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        public async Task<int> Handle(
            CreateOrderCommand request, 
            CancellationToken cancellationToken
            )
        {
            var newOrder = new OrderDto
            {
                id = 1,
                createdDate = DateTime.UtcNow,
                orderCode = request.orderCode,
                totalAmount = request.totalAmount
            };

            //save.....to anywhere

            return newOrder.id;
        }
    }
}
