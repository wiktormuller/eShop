using eShop.Models.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IOrderStatus
    {
        IEnumerable<OrderStatus> GetOrderStatuses();
        OrderStatus GetOrderStatus(int id);
        void AddOrderStatus(OrderStatus orderStatus);
        void RemoveOrderStatus(OrderStatus orderStatus);
        void UpdateOrderStatus(OrderStatus orderStatus);
    }
}
