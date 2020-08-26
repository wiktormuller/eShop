using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Services
{
    public class ProductService : IProduct
    {
        private readonly eShopDbContext _context;

        public ProductService(eShopDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id).First();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products;
            return products;
        }

        public void RemoveProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
