using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.EFCore.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(p => p.OrderId).IsRequired();
        }
    }
}
