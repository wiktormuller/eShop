using eShop.Domain.Entities;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IShoppingCart
    {
        Task AddCartItem(string username, int productId, int quantity);
        Task RemoveItem(int shoppingCartId, int cartItemId);

        Task<ShoppingCart> GetExistingOrCreateNewShoppingCart(string email);
        Task<ShoppingCart> GetShopingCartByEmail(string email);

        Task ClearShoppingCart(string username);
    }
}
