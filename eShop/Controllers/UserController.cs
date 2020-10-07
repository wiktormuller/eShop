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
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var models = await _userService.GetUsers();

            var users = models.Select(c =>
                new UserReadDTO()
                {
                    UserId = c.UserId,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Email = c.Email
                }).ToList();
            
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            var model = new UserReadDTO()
            {
                UserId = user.UserId,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email
            };
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUser([FromBody] UserCreateDTO userCreateDto) //Return type is UserReadDTO as a HTTP response
        {
            var model = new User
            (
                userCreateDto.UserId,
                userCreateDto.Email,
                userCreateDto.Firstname,
                userCreateDto.Lastname,
                userCreateDto.Username,
                userCreateDto.Role,
                userCreateDto.Password,
                userCreateDto.Salt
            );
            await _userService.AddUser(model);

            var userReadDto = new UserReadDTO
            {
                UserId = model.UserId,
                Email = model.Email,
                Role = model.Role,
                Username = model.Username,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
            };

            return CreatedAtRoute(nameof(GetUser), new { Id = userReadDto.UserId }, userReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDTO updatedUser)
        {
            var userModelFromRepo = await _userService.GetUser(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }

            userModelFromRepo.SetFirstname(updatedUser.Firstname);
            userModelFromRepo.SetLastname(updatedUser.Lastname);
            userModelFromRepo.SetEmail(updatedUser.Email);

            await _userService.UpdateUser(userModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateCustomer(int id, JsonPatchDocument<UserUpdateDTO> patchDoc)
        {
            var customerModelFromRepo = await _userService.GetUser(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            var customerToPatch = new UserUpdateDTO
            {
                Firstname = customerModelFromRepo.Firstname,
                Lastname = customerModelFromRepo.Lastname,
                Email = customerModelFromRepo.Email
            };

            patchDoc.ApplyTo(customerToPatch, ModelState);

            if(!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            customerModelFromRepo.SetFirstname(customerToPatch.Firstname);
            customerModelFromRepo.SetLastname(customerToPatch.Lastname);
            customerModelFromRepo.SetEmail(customerToPatch.Email);

            await _userService.UpdateUser(customerModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var customer = await _userService.GetUser(id);
            if(customer == null)
            {
                return NotFound();
            }
            await _userService.RemoveUser(customer);
            return NoContent();
        }
    }
}
