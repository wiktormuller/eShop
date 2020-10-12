using System;
using System.Collections.Generic;

namespace eShop.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
