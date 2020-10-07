using System;

namespace eShop.Models.Entities
{
    public class Product
    {
        public int ProductId { get;  protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public ProductColor Color { get; protected set; }
        public string Description { get; protected set; }

        public Product(int productId, string name, decimal price, ProductColor color, string description)
        {
            ProductId = productId;
            SetName(name);
            SetPrice(price);
            SetColor(color);
            SetDescription(description);
        }

        public void SetColor(ProductColor color)
        {
            Color = color;
        }

        public void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException();
            }
            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if(price <= 0)
            {
                throw new ArgumentException();
            }
            Price = price;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            Name = name;
        }
    }
}
