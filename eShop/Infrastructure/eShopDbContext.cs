using eShop.Infrastructure.Configuration;
using eShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Infrastructure
{
    public class eShopDbContext : DbContext
    {
        public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Relationships
            //Entity configurations
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new AddressConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
