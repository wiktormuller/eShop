using System;

namespace eShop.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        //Relations
        public int ShoppingCartId { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }

        public CartItem(int productId, int quantity, int shoppingCartId)
        {
            SetProductId(productId);
            SetQuantity(quantity);
            SetShoppingCartId(shoppingCartId);
        }

        public void SetShoppingCartId(int shoppingCartId)
        {
            if(shoppingCartId < 0)
            {
                throw new ArgumentException();
            }
            ShoppingCartId = shoppingCartId;
        }

        public void SetQuantity(int quantity)
        {
            if(quantity == 0)
            {
                throw new ArgumentException();
            }
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(quantity > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            Quantity = quantity;
        }

        public void SetProductId(int productId)
        {
            if(productId < 0)
            {
                throw new ArgumentException();
            }
            ProductId = productId;
        }
    }
}
