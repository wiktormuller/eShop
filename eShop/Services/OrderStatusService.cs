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
            if(orderStatus == null)
            {
                throw new ArgumentNullException();
            }
            _context.OrderStatuses.Add(orderStatus);
            _context.SaveChanges();
        }

        public OrderStatus GetOrderStatus(int id)
        {
            var orderStatus = _context.OrderStatuses.Where(o => o.OrderStatusId == id).First();
            return orderStatus;
        }

        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            var orderStatuses = _context.OrderStatuses;
            return orderStatuses;
        }

        public void RemoveOrderStatus(OrderStatus orderStatus)
        {
            if(orderStatus == null)
            {
                throw new ArgumentNullException();
            }
            _context.OrderStatuses.Remove(orderStatus);
            _context.SaveChanges();
        }

        public void UpdateOrderStatus(OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            _context.SaveChanges();
        }
    }
}
