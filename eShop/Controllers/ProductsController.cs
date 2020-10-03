using System.Collections.Generic;
using System.Linq;
using eShop.DTO;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<IEnumerable<ProductReadDTO>> GetProducts()
        {
            var products = _productService.GetProducts().Select(p =>
                new ProductReadDTO()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Color = p.Color,
                    Description = p.Description
                }).ToList();

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            var model = new ProductReadDTO
            {
                Name = product.Name,
                Price = product.Price,
                Color = product.Color,
                Description = product.Description
            };

            return Ok(model);
        }

        [HttpPost]
        public ActionResult<ProductReadDTO> CreateProduct([FromBody] ProductCreateDTO productCreateDto)
        {
            var model = new Product
            (
                productCreateDto.ProductId,
                productCreateDto.Name,
                productCreateDto.Price,
                productCreateDto.Color,
                productCreateDto.Description
            );
            _productService.AddProduct(model);

            var productReadDto = new ProductReadDTO
            {
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                Description = model.Description
            };

            return CreatedAtRoute(nameof(GetProduct), new { Id = productReadDto.ProductId }, productReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            var productModelFromRepo = _productService.GetProduct(id);
            if(productModelFromRepo == null)
            {
                return NotFound();
            }

            productModelFromRepo.SetName(product.Name);
            productModelFromRepo.SetPrice(product.Price);
            productModelFromRepo.SetColor(product.Color);
            productModelFromRepo.SetDescription(product.Description);

            _productService.UpdateProduct(productModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductUpdateDTO> patchDoc)
        {
            var productModelFromRepo = _productService.GetProduct(id);
            if(productModelFromRepo == null)
            {
                return NotFound();
            }

            var productToPatch = new ProductUpdateDTO
            {
                Name = productModelFromRepo.Name,
                Price = productModelFromRepo.Price,
                Color = productModelFromRepo.Color,
                Description = productModelFromRepo.Description
            };

            patchDoc.ApplyTo(productToPatch, ModelState);

            if(!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            productModelFromRepo.SetName(productToPatch.Name);
            productModelFromRepo.SetPrice(productToPatch.Price);
            productModelFromRepo.SetColor(productToPatch.Color);
            productModelFromRepo.SetDescription(productToPatch.Description);

            _productService.UpdateProduct(productModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            _productService.RemoveProduct(product);
            return NoContent();
        }
    }
}
