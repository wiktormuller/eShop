using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.EFCore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(p => p.Email).IsRequired();
            entity.Property(p => p.Password).IsRequired();
            entity.Property(p => p.Role).IsRequired();
            entity.Property(p => p.UserId).IsRequired();
            entity.Property(p => p.Username).IsRequired().HasMaxLength(25);
        }
    }
}
