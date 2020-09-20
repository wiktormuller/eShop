using eShop.DTO;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    [Authorize(Policy = "admin")]
    [Route("api/[controller]")]
    [ApiController]
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
            var customers = _customerService.GetCustomers().Select(c =>
                new CustomerReadDTO()
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email
                }).ToList();
            
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            var model = new CustomerReadDTO()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
            return Ok(model);
        }

        [HttpPost]
        public ActionResult<CustomerReadDTO> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto) //Return type is CustomerReadDTO as a HTTP response
        {
            var model = new Customer
            {
                FirstName = customerCreateDto.FirstName,
                LastName = customerCreateDto.LastName,
                Email = customerCreateDto.Email
            };
            _customerService.AddCustomer(model);

            var commandReadDto = new CustomerReadDTO
            {
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            return CreatedAtRoute(nameof(GetCustomer), new { Id = commandReadDto.CustomerId }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerUpdateDTO updatedCustomer)
        {
            var customerModelFromRepo = _customerService.GetCustomer(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            customerModelFromRepo.FirstName = updatedCustomer.FirstName;
            customerModelFromRepo.LastName = updatedCustomer.LastName;
            customerModelFromRepo.Email = updatedCustomer.Email;

            _customerService.UpdateCustomer(customerModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCustomer(int id, JsonPatchDocument<CustomerUpdateDTO> patchDoc)
        {
            var customerModelFromRepo = _customerService.GetCustomer(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            var customerToPatch = new CustomerUpdateDTO
            {
                FirstName = customerModelFromRepo.FirstName,
                LastName = customerModelFromRepo.LastName,
                Email = customerModelFromRepo.Email
            };

            patchDoc.ApplyTo(customerToPatch, ModelState);

            if(!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            customerModelFromRepo.FirstName = customerToPatch.FirstName;
            customerModelFromRepo.LastName = customerToPatch.LastName;
            customerModelFromRepo.Email = customerToPatch.Email;

            _customerService.UpdateCustomer(customerModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if(customer == null)
            {
                return NotFound();
            }
            _customerService.RemoveCustomer(customer);
            return NoContent();
        }
    }
}
