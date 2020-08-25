﻿using eShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(p => p.OrderId).IsRequired();
            entity.Property(p => p.Customer).IsRequired();
            entity.Property(p => p.OrderStatus).IsRequired();
        }
    }
}
