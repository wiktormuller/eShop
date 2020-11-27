using System;

namespace eShop.Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; private set; }
        public int Quantity { get; set; }   //Maybe private?
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; private set; }

        public CartItem(int productId, int quantity, decimal unitPrice, decimal totalPrice)
        {
            SetQuantity(quantity);
            SetUnitPrice(unitPrice);
            SetTotalPrice(totalPrice);
            SetProductId(productId);
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

        public void SetUnitPrice(decimal unitPrice)
        {
            UnitPrice = unitPrice;
        }
        
        public void SetTotalPrice(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }

        private void SetProductId(int productId)
        {
            if(productId < 0)
            {
                throw new ArgumentException();
            }
            ProductId = productId;
        }
    }
}
