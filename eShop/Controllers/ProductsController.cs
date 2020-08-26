using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductsController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProcut")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }
    }
}
