using eShop.Domain.Enums;
using System;

namespace eShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get;  private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        //Relations
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }

        public Order(OrderStatus orderStatus)
        {
            CreatedAt = DateTime.Now;
            SetOrderStatus(orderStatus);
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }
    }
}
