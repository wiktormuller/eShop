using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.Property(p => p.ProductId).IsRequired();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(120);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.Color).IsRequired();
            entity.Property(p => p.Description).IsRequired().HasMaxLength(1000);
        }
    }
}
