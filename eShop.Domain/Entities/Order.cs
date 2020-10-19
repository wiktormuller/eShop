using eShop.Domain.Enums;
using System;

namespace eShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get;  set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Initiated;

        public int UserId { get; set; }
        public User User { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
