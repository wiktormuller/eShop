using eShop.Domain.Entities;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface ICartItem
    {
        Task<CartItem> GetCartItem(int id);
        Task AddCartItem(CartItem cartItem);
    }
}
