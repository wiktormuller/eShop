using System;
using System.Collections.Generic;

namespace eShop.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IEnumerable<CartItem> CartItems { get; private set; }

        public ShoppingCart()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
