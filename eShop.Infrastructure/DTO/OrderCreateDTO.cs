using eShop.Domain.Entities;
using eShop.Domain.Enums;
using System.Collections.Generic;

namespace eShop.Infrastructure.DTO
{
    public class OrderCreateDTO
    {
        public int OrderId { get; set; }
        public User User { get; set; }
    }
}
