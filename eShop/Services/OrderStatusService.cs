using eShop.Infrastructure;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class OrderStatusService : IOrderStatus
    {
        private readonly eShopDbContext _context;

        public OrderStatusService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderStatus(OrderStatus orderStatus)
        {
            if(orderStatus == null)
            {
                throw new ArgumentNullException();
            }
            _context.OrderStatuses.Add(orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderStatus> GetOrderStatus(int id)
        {
            var orderStatus = await _context.OrderStatuses.Where(o => o.OrderStatusId == id).FirstOrDefaultAsync();
            return orderStatus;
        }

        public async Task<IEnumerable<OrderStatus>> GetOrderStatuses()
        {
            var orderStatuses = await _context.OrderStatuses.ToListAsync();
            return orderStatuses;
        }

        public async Task RemoveOrderStatus(OrderStatus orderStatus)
        {
            if(orderStatus == null)
            {
                throw new ArgumentNullException();
            }
            _context.OrderStatuses.Remove(orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            await _context.SaveChangesAsync();
        }
    }
}
