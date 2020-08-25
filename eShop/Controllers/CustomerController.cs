using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomersController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public  ActionResult<Customer> GetCustomer(Guid id)
        {
            var customer = _customerService.GetCustomer(id);
            return Ok(customer);
        }
    }
}
