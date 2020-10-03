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
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products;
            return products;
        }

        public void RemoveProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
