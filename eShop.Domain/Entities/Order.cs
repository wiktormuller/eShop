using eShop.Domain.Enums;
using System;

namespace eShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get;  set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User User { get;  set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Initiated;
        public ShoppingCart ShoppingCart { get; set; }
    }
}
