﻿using eShop.Models.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IOrderStatus
    {
        IEnumerable<OrderStatus> GetOrderStatuses();
        OrderStatus GetOrderStatus(Guid id);
        void AddOrderStatus(OrderStatus orderStatus);
        void RemoveOrderStatus(Guid id);
        void UpdateOrderStatus(OrderStatus orderStatus);
    }
}
