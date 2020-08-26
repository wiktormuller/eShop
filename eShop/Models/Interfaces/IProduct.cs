using eShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models.Interfaces
{
    interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        void AddProduct(Product product);
        void RemoveProduct(Guid id);
        void UpdateProduct(Product product);
    }
}
