using eShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace eShop.Infrastructure.DTO
{
    public class ShoppingCartReadDTO
    {
        public int ShoppingCartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
