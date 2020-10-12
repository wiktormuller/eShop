using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
