using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            return Ok(order);
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            /*var orderModel = _orderService.GetOrder(id);
            if(orderModel == null)
            {
                return NotFound();
            }*/

            _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if(order == null)
            {
                return NotFound();
            }
            _orderService.RemoveOrder(order);
            return NoContent();
        }
    }
}
