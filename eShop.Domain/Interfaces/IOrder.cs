using eShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task AddOrder(Order order);
        Task RemoveOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
