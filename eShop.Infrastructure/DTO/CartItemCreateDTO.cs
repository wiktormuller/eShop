﻿namespace eShop.Infrastructure.DTO
{
    public class CartItemCreateDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
