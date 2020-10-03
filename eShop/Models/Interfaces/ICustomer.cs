using eShop.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Models.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task AddCustomer(Customer customer);
        Task RemoveCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
