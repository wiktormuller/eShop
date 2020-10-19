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
    }
}
