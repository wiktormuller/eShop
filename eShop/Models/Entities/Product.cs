using System;

namespace eShop.Models.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public ProductColor Color { get; private set; }
        public string Description { get; private set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
