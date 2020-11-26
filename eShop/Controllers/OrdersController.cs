using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using eShop.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrdersController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<OrderReadDTO>> GetOrder(int id)
        {
            var model = await _orderService.GetOrder(id);

            if (model == null)
            {
                return NotFound();
            }

            var order = new OrderReadDTO
            {
                OrderId = model.OrderId,
                CreatedAt = model.CreatedAt,
                User = model.User,
                OrderStatus = model.OrderStatus
            };

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            if(order == null)
            {
                return NotFound();
            }
            await _orderService.RemoveOrder(order);
            return NoContent();
        }
    }
}
