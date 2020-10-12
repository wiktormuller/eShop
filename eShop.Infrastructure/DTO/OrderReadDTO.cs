using eShop.Domain.Entities;
using eShop.Domain.Enums;
using System;
using System.Collections.Generic;

namespace eShop.Infrastructure.DTO
{
    public class OrderReadDTO
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<CartItem> OrderItems { get; set; }
    }
}
