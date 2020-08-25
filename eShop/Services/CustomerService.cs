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
            throw new NotImplementedException();
        }

        public Customer GetCustomer(Guid id)
        {
            var customer = _context.Customers.Where(c => c.CustomerId == id).First();
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public void RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
