﻿using eShop.Domain.Enums;
using System;

namespace eShop.Domain.Entities
{
    public class Product
    {
        public int ProductId { get;  private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public ProductColor Color { get; private set; }
        public string Description { get; private set; }

        //Relations
        public int CategoryId { get; private set; }

        public Product(string name, decimal price, ProductColor color, string description, int categoryId)
        {
            SetName(name);
            SetPrice(price);
            SetColor(color);
            SetDescription(description);
            SetCategory(categoryId);
        }

        public void SetCategory(int categoryId)
        {
            if(categoryId < 0)
            {
                throw new ArgumentException();
            }
            CategoryId = categoryId;
        }

        public void SetColor(ProductColor color)
        {
            Color = color;
        }

        public void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException();
            }
            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if(price <= 0)
            {
                throw new ArgumentException();
            }
            Price = price;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            Name = name;
        }
    }
}
