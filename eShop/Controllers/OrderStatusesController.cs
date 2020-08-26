using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<IEnumerable<OrderStatus>> GetOrderStatuses()
        {
            var orderStatuses = _orderStatusService.GetOrderStatuses();
            return Ok(orderStatuses);
        }

        [HttpGet("{id}", Name = "GetOrderStatus")]
        public ActionResult<OrderStatus> GetOrderStatus(int id)
        {
            var orderStatus = _orderStatusService.GetOrderStatus(id);
            return Ok(orderStatus);
        }
    }
}
