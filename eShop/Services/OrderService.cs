using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Services
{
    public class OrderService : IOrder
    {
        private readonly eShopDbContext _context;

        public OrderService(eShopDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            var order = _context.Orders.Where(o => o.OrderId == id).First();
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _context.Orders;
            return orders;
        }

        public void RemoveOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
