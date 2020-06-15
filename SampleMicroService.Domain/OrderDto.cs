using System;

namespace SampleMicroService.Domain
{
    public class OrderDto
    {
        public int id { get; set; }
        public string orderCode { get; set; }
        public decimal totalAmount { get; set; }
        public DateTime createdDate { get; set; }
    }
}
