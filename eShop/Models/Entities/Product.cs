﻿using eShop.Exceptions;
using System;

namespace eShop.Models.Entities
{
    public class Product
    {
        public int ProductId { get;  protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public ProductColor Color { get; protected set; }
        public string Description { get; protected set; }

        public Product(int productId, string name, decimal price, string description)
        {
            ProductId = productId;
            SetName(name);
            SetPrice(price);
            SetDescription(description);
        }

        private void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new DomainException(DomainErrorCodes.InvalidDescription, "Invalid description.");
            }
            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if(price <= 0)
            {
                throw new DomainException(DomainErrorCodes.InvalidPrice, "Invalid price");
            }
            Price = price;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new DomainException(DomainErrorCodes.InvalidName, "Invalid product name.");
            }
            Name = name;
        }
    }
}
