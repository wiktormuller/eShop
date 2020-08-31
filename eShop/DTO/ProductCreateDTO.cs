﻿using eShop.Models;

namespace eShop.DTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductColor Color { get; set; }
        public string Description { get; set; }
    }
}
