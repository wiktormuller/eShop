using eShop.Infrastructure;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Services
{
    public class OrderService : IOrder
    {
        private readonly eShopDbContext _context;

        public OrderService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task RemoveOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
