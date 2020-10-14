using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public readonly IShoppingCart _shoppingCartService;

        public ShoppingCartController(IShoppingCart shoppingCart)
        {
            _shoppingCartService = shoppingCart;
        }

        [HttpGet("{id", Name = "GetShoppingCart")]
        public async Task<ActionResult<ShoppingCartReadDTO>> GetShoppingCart(int id)
        {
            var shoppingCart = _shoppingCartService.GetShopingCart(id);
            return Ok(shoppingCart);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartReadDTO>> CreateShoppingCart([FromBody] ShoppingCartCreateDTO shoppingCartCreateDTO)
        {
            var model = new ShoppingCart
            (
                
            );
        }

        [HttpPost("{id}", Name = "PopulateShoppingCart")]
        public async Task<ActionResult<ShoppingCartReadDTO>> PopulateShoppingCart([FromBody] ShoppingCartPopulateDTO shoppingCartPopulateDTO)
        {

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShoppingCart(int id)
        {
            var shoppingCart = await _shoppingCartService.GetShopingCart(id);
            if(shoppingCart == null)
            {
                return NotFound()
            }
            await _shoppingCartService.RemoveShoppingCart(shoppingCart);
            return NoContent();
        }
    }
}
