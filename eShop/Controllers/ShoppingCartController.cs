using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using eShop.Infrastructure.DTO;
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

        [HttpGet("{id}", Name = "GetShoppingCart")]
        public async Task<ActionResult<ShoppingCartReadDTO>> GetShoppingCart(int id)
        {
            var model = await _shoppingCartService.GetShopingCart(id);
            var shoppingCart = new ShoppingCartReadDTO
            {
                ShoppingCartId = model.ShoppingCartId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                CartItems = model.CartItems
            };

            return Ok(shoppingCart);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartReadDTO>> CreateShoppingCart(/*[FromBody] ShoppingCartCreateDTO shoppingCartCreateDto*/)
        {
            var model = new ShoppingCart();
            await _shoppingCartService.AddShoppingCart(model);

            var shoppingCartReadDto = new ShoppingCartReadDTO
            {
                ShoppingCartId = model.ShoppingCartId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                CartItems = model.CartItems
            };
            
            return CreatedAtRoute(nameof(GetShoppingCart), new { Id = shoppingCartReadDto.ShoppingCartId }, shoppingCartReadDto);
        }

        [HttpPost("{id}", Name = "PopulateShoppingCart")]
        public async Task<ActionResult<CartItemReadDTO>> PopulateShoppingCart([FromBody] CartItemCreateDTO cartItemCreateDto)
        {
            var model = new CartItem
            {
                ProductId = cartItemCreateDto.ProductId,
                Quantity = cartItemCreateDto.Quantity,
                ShoppingCartId = cartItemCreateDto.ShoppingCartId
            };
            await _shoppingCartService.AddCartItem(model);

            var cartItemReadDto = new CartItemReadDTO
            {
                CartItemId = model.CartItemId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            return CreatedAtRoute(nameof(GetShoppingCart), new { Id = cartItemReadDto.CartItemId }, cartItemReadDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShoppingCart(int id)
        {
            var shoppingCart = await _shoppingCartService.GetShopingCart(id);
            if(shoppingCart == null)
            {
                return NotFound();
            }
            await _shoppingCartService.RemoveShoppingCart(shoppingCart);
            return NoContent();
        }
    }
}
