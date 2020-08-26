using System;
using System.Collections.Generic;

namespace eShop.Models.Entities
{
    public class Order
    {
        public int OrderId { get; private set; }
        public Customer Customer { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
    }
}
