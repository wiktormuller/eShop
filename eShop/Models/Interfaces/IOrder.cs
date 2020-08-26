using eShop.Models.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(Guid id);
        void AddOrder(Order order);
        void RemoveOrder(Guid id);
        void UpdateOrder(Order order);
    }
}
