using eShop.Domain.Enums;

namespace eShop.Domain.Entities
{
    public class OrderStatus
    {
        public int OrderStatusId { get;  set; }
        public Status Status { get;  set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
