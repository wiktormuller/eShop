using eShop.DTO;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var models = await _customerService.GetCustomers();

            var customers = models.Select(c =>
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
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);
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
        public async Task<ActionResult<CustomerReadDTO>> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto) //Return type is CustomerReadDTO as a HTTP response
        {
            var model = new Customer
            (
                customerCreateDto.CustomerId,
                customerCreateDto.FirstName,
                customerCreateDto.LastName,
                customerCreateDto.Email
            );
            await _customerService.AddCustomer(model);

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
        public async Task<ActionResult> UpdateCustomer(int id, CustomerUpdateDTO updatedCustomer)
        {
            var customerModelFromRepo = await _customerService.GetCustomer(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            customerModelFromRepo.SetFirstName(updatedCustomer.FirstName);
            customerModelFromRepo.SetLastName(updatedCustomer.LastName);
            customerModelFromRepo.SetEmail(updatedCustomer.Email);

            await _customerService.UpdateCustomer(customerModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateCustomer(int id, JsonPatchDocument<CustomerUpdateDTO> patchDoc)
        {
            var customerModelFromRepo = await _customerService.GetCustomer(id);
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

            customerModelFromRepo.SetFirstName(customerToPatch.FirstName);
            customerModelFromRepo.SetLastName(customerToPatch.LastName);
            customerModelFromRepo.SetEmail(customerToPatch.Email);

            await _customerService.UpdateCustomer(customerModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            if(customer == null)
            {
                return NotFound();
            }
            await _customerService.RemoveCustomer(customer);
            return NoContent();
        }
    }
}
