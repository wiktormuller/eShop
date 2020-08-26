using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
