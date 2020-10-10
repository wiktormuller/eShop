using System.Collections.Generic;

namespace eShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get;  set; }
        public User User { get;  set; }
        public OrderStatus OrderStatus { get;  set; }
        public IEnumerable<Product> Products { get;  set; }
    }
}
