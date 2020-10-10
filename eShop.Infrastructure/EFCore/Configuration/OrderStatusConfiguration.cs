using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.EFCore.Configuration
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> entity)
        {
            entity.Property(p => p.OrderStatusId).IsRequired();
            entity.Property(p => p.Status).IsRequired();
        }
    }
}
