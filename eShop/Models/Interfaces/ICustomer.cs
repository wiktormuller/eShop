using eShop.Models.Entities;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
