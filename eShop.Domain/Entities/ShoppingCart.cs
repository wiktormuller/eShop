using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; private set; }
        public string Email { get; set; }    //Maybe private?
        public decimal TotalPrice { get; set; }
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();   //How to ommit that?


        public void AddItem(int productId, int quantity, decimal unitPrice = 0.0M)
        {
            var existingItem = CartItems.FirstOrDefault(i => i.ProductId == productId); //NULL?

            if(existingItem == null)
            {
                var totalPrice = quantity * unitPrice;
                CartItems.Add(new CartItem(productId, quantity, unitPrice, totalPrice));
            }
            else
            {
                existingItem.Quantity+=quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
        }

        public void RemoveItem(int cartItemId)
        {
            var removedItem = CartItems.FirstOrDefault(x => x.CartItemId == cartItemId);
            if(removedItem != null)
            {
                CartItems.Remove(removedItem);
            }
        }

        public void ClearShoppingCart()
        {
            CartItems.Clear();
        }
    }
}
