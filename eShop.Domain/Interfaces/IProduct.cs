using eShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
