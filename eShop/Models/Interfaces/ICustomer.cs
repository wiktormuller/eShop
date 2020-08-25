using eShop.Models.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(Guid id);
        void AddCustomer(Customer customer);
        void RemoveCustomer(Guid id);
        void UpdateCustomer(Customer customer);
    }
}
