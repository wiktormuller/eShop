using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Infrastructure.DTO;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
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
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetProducts()
        {
            var models = await _productService.GetProducts();
            
            var products = models.Select(p =>
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
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);

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
        public async Task<ActionResult<ProductReadDTO>> CreateProduct([FromBody] ProductCreateDTO productCreateDto)
        {
            var model = new Product
            (
                productCreateDto.ProductId,
                productCreateDto.Name,
                productCreateDto.Price,
                productCreateDto.Color,
                productCreateDto.Description
            );
            await _productService.AddProduct(model);

            var productReadDto = new ProductReadDTO
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                Description = model.Description
            };

            return CreatedAtRoute(nameof(GetProduct), new { Id = productReadDto.ProductId }, productReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            var productModelFromRepo = await _productService.GetProduct(id);
            if(productModelFromRepo == null)
            {
                return NotFound();
            }

            productModelFromRepo.SetName(product.Name);
            productModelFromRepo.SetPrice(product.Price);
            productModelFromRepo.SetColor(product.Color);
            productModelFromRepo.SetDescription(product.Description);

            await _productService.UpdateProduct(productModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateProduct(int id, JsonPatchDocument<ProductUpdateDTO> patchDoc)
        {
            var productModelFromRepo = await _productService.GetProduct(id);
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

            await _productService.UpdateProduct(productModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            await _productService.RemoveProduct(product);
            return NoContent();
        }
    }
}
