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
        public void AddCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public void RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            //_context.Entry(customer).State = EntityState.Modified;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(); //???How it works
        }
    }
}
