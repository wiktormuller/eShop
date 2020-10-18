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
    public class CartItemService : ICartItem
    {
        private readonly eShopDbContext _context;

        public CartItemService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new ArgumentNullException();
            }
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            var cartItem = await _context.CartItems.Where(c => c.CartItemId == id).FirstOrDefaultAsync();
            return cartItem;
        }
    }
}
