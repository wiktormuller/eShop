using System;

namespace eShop.Models.Entities
{
    public class OrderStatus
    {
        public int OrderStatusId { get; private set; }
        public Status Status { get; private set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
