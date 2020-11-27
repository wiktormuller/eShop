using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCart
    {
        public eShopDbContext _context;

        public ShoppingCartService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItem(string email, int productId, int quantity)
        {
            var shoppingCart = await GetExistingOrCreateNewShoppingCart(email);

            var product = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            shoppingCart.AddItem(productId, quantity, product.Price);
            await _context.SaveChangesAsync();

            await CalculateTotalPrice(shoppingCart);
        }

        public async Task RemoveItem(int shoppingCartId, int cartItemId)
        {
            var shoppingCart = await _context.ShoppingCarts.Where(x => x.ShoppingCartId == shoppingCartId).FirstOrDefaultAsync();
            shoppingCart.RemoveItem(cartItemId);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetExistingOrCreateNewShoppingCart(string email)
        {
            var shoppingCart = await _context.ShoppingCarts.Where(x => x.Email == email).FirstOrDefaultAsync();

            if(shoppingCart != null)
            {
                return shoppingCart;
            }

            var newShoppingCart = new ShoppingCart()
            {
                Email = email
            };
            await _context.ShoppingCarts.AddAsync(newShoppingCart);
            await _context.SaveChangesAsync();

            return newShoppingCart;
        }

        public async Task<ShoppingCart> GetShopingCartByEmail(string email)
        {
            var shoppingCart = await _context.ShoppingCarts.Where(o => o.Email == email)
                .Include(cartItem => cartItem.CartItems)
                .FirstOrDefaultAsync();

            return shoppingCart;
        }

        public async Task ClearShoppingCart(string email)
        {
            var shoppingCart = await _context.ShoppingCarts.Where(x => x.Email == email).FirstOrDefaultAsync();

            if(shoppingCart == null)
            {
                throw new InvalidOperationException("Submitted order should have cart.");
            }

            shoppingCart.ClearShoppingCart();
            await _context.SaveChangesAsync();
        }

        private async Task CalculateTotalPrice(ShoppingCart shoppingCart)
        {
            shoppingCart.TotalPrice = _context.CartItems.Sum(x => x.TotalPrice);
            await _context.SaveChangesAsync();  //How to do it better?
        }
    }
}
