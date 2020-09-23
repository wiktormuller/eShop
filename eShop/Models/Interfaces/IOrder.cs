using eShop.Models.Entities;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void UpdateOrder(Order order);
    }
}
