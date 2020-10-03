using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class CustomerService : ICustomer
    {
        private readonly eShopDbContext _context;

        public CustomerService(eShopDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _context.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
           _context.Update(customer);
           await _context.SaveChangesAsync();
        }
    }
}
