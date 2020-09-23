using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void UpdateCustomer(Customer customer)
        {
           _context.Update(customer);
           _context.SaveChanges();
        }
    }
}
