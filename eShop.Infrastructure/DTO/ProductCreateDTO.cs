using eShop.Domain.Entities;
using eShop.Domain.Enums;

namespace eShop.Infrastructure.DTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductColor Color { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
