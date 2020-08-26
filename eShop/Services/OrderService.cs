using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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

        public void RemoveOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
