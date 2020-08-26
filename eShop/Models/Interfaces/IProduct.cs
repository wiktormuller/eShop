using eShop.Models.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        void AddProduct(Product product);
        void RemoveProduct(Guid id);
        void UpdateProduct(Product product);
    }
}
