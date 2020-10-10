using eShop.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace eShop.Infrastructure.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            throw new NotImplementedException();
            /*
            entity.Property(p => p.City).IsRequired();
            entity.Property(p => p.Country).IsRequired();
            entity.Property(p => p.Street).IsRequired();
            entity.Property(p => p.ZipCode).IsRequired();
            */
        }

        //https://github.com/dotnet/efcore/issues/15681
    }
}
