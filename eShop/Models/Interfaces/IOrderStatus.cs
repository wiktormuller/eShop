using eShop.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Models.Interfaces
{
    public interface IOrderStatus
    {
        Task<IEnumerable<OrderStatus>> GetOrderStatuses();
        Task<OrderStatus> GetOrderStatus(int id);
        Task AddOrderStatus(OrderStatus orderStatus);
        Task RemoveOrderStatus(OrderStatus orderStatus);
        Task UpdateOrderStatus(OrderStatus orderStatus);
    }
}
