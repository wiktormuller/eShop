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

        public async Task AddShoppingCart(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null)
            {
                throw new ArgumentNullException();
            }
            _context.ShoppingCarts.Add(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShopingCart(int id)
        {
            var shoppingCart = await _context.ShoppingCarts.Where(o => o.ShoppingCartId == id)
                .Include(cartItem => cartItem.CartItems)
                .FirstOrDefaultAsync();

            return shoppingCart;
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            if(cartItem == null)
            {
                throw new ArgumentNullException();
            }
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveShoppingCart(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null)
            {
                throw new ArgumentNullException();
            }
            _context.ShoppingCarts.Remove(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(shoppingCart);
            await _context.SaveChangesAsync();
        }
    }
}
