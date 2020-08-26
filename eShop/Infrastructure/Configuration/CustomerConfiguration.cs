using eShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(20);
            entity.Property(p => p.Email).IsRequired();

            entity.OwnsOne(p => p.Address);
        }
    }
}
