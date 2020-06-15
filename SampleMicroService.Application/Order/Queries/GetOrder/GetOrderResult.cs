using System;

namespace SampleMicroService.Application.Order.Queries.GetOrder
{
    public class GetOrderResult
    {
        public int id { get; set; }
        public string code { get; set; }
        public decimal totalAmount { get; set; }
        public DateTime createdDate { get; set; }
    }
}
