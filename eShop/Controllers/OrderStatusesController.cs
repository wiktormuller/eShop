using System.Collections.Generic;
using System.Threading.Tasks;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly IOrderStatus _orderStatusService;

        public OrderStatusesController(IOrderStatus orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> GetOrderStatuses()
        {
            var orderStatuses = await _orderStatusService.GetOrderStatuses();
            return Ok(orderStatuses);
        }

        [HttpGet("{id}", Name = "GetOrderStatus")]
        public async Task<ActionResult<OrderStatus>> GetOrderStatus(int id)
        {
            var orderStatus = await _orderStatusService.GetOrderStatus(id);
            return Ok(orderStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderStatus(int id, OrderStatus orderStatus)
        {
            var orderStatusModel = await _orderStatusService.GetOrderStatus(id);
            if(orderStatusModel == null)
            {
                return NotFound();
            }

            await _orderStatusService.UpdateOrderStatus(orderStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderStatus>> DeleteOrderStatus(int id)
        {
            var orderStatus = await _orderStatusService.GetOrderStatus(id);
            if(orderStatus == null)
            {
                return NotFound();
            }
            await _orderStatusService.RemoveOrderStatus(orderStatus);
            return NoContent();
        }
    }
}
