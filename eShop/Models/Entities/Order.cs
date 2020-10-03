using System.Collections.Generic;

namespace eShop.Models.Entities
{
    public class Order
    {
        public int OrderId { get;  set; }
        public Customer Customer { get;  set; }
        public OrderStatus OrderStatus { get;  set; }
        public IEnumerable<Product> Products { get;  set; }
    }
}
