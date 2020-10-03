using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            return Ok(order);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, Order order)
        {
            var orderModel = await _orderService.GetOrder(id);
            if(orderModel == null)
            {
                return NotFound();
            }

            await _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
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
