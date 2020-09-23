using eShop.Models.Entities;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
    }
}
