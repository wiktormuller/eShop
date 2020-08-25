using System;

namespace eShop.Models.Entities
{
    public class OrderStatus
    {
        public Guid OrderStatusId { get; private set; }
        public Status Status { get; private set; }
    }
}
