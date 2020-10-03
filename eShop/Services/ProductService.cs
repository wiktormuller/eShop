using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class ProductService : IProduct
    {
        private readonly eShopDbContext _context;

        public ProductService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task RemoveProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
