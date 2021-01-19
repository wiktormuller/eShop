using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using eShop.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public readonly IShoppingCart _shoppingCartService;

        public ShoppingCartController(IShoppingCart shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet(Name = "GetShoppingCartByEmail")]
        public async Task<ActionResult<ShoppingCartReadDTO>> GetShoppingCartByEmail()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var model = await _shoppingCartService.GetShopingCartByEmail(email);    //.Result

            if (model == null)
            {
                return NotFound();
            }

            var shoppingCart = new ShoppingCartReadDTO
            {
                ShoppingCartId = model.ShoppingCartId,
                TotalPrice = model.TotalPrice,
                CartItems = model.CartItems
            };

            return Ok(shoppingCart);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartReadDTO>> AddCartItemToShoppingCart(CartItemCreateDTO cartItemCreateDto)
        {
            if(cartItemCreateDto == null)
            {
                return BadRequest();
            }

            var email = User.FindFirst(ClaimTypes.Email).Value;

            await _shoppingCartService.AddCartItem(
                email,
                cartItemCreateDto.ProductId,
                cartItemCreateDto.Quantity);

            var model = await _shoppingCartService.GetShopingCartByEmail(email);
            var shoppingCartReadDto = new ShoppingCartReadDTO
            {
                ShoppingCartId = model.ShoppingCartId,
                TotalPrice = model.TotalPrice,
                CartItems = model.CartItems
            };

            return CreatedAtRoute(nameof(GetShoppingCartByEmail), new { Id = shoppingCartReadDto.ShoppingCartId }, shoppingCartReadDto);
        }
    }
}
