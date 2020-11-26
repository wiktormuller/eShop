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
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItem _cartItemService;

        public CartItemsController(ICartItem cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<ActionResult<CartItemReadDTO>> CreateCartItem([FromBody] CartItemCreateDTO cartItemCreateDto)
        {
            if (cartItemCreateDto == null)
            {
                return BadRequest();
            }

            var model = new CartItem
            (
                cartItemCreateDto.ProductId,
                cartItemCreateDto.Quantity,
                cartItemCreateDto.ShoppingCartId
            );
            await _cartItemService.AddCartItem(model);

            var cartItemReadDto = new CartItemReadDTO
            {
                CartItemId = model.CartItemId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            //return CreatedAtRoute(nameof(GetCartItem), new { Id = cartItemReadDto.CartItemId }, cartItemReadDto); //What about that?!
            return Ok();
        }
    }
}
