using System;

namespace eShop.Models.Entities
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; private set; }
        public Status Status { get; private set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
