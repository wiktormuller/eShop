using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Services
{
    public class OrderStatusService : IOrderStatus
    {
        private readonly eShopDbContext _context;

        public OrderStatusService(eShopDbContext context)
        {
            _context = context;
        }

        public void AddOrderStatus(OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }

        public OrderStatus GetOrderStatus(Guid id)
        {
            var orderStatus = _context.OrderStatuses.Where(o => o.OrderStatusId == id).First();
            return orderStatus;
        }

        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            var orderStatuses = _context.OrderStatuses;
            return orderStatuses;
        }

        public void RemoveOrderStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}
