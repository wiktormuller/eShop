using eShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task<ShoppingCart> GetShopingCart(int id);
        Task AddShoppingCart(ShoppingCart shoppingCart);
        Task RemoveShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(ShoppingCart shoppingCart);
    }
}
