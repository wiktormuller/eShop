using System;
using System.Threading.Tasks;
using eShop.Infrastructure.DTO;
using eShop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;
        private readonly IJwt _jwtService;
        private readonly IUser _userService;

        public AuthController(IAuth authService, IJwt jwtService, IUser userService)
        {
            _authService = authService;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login(LoginDTO loginDto)
        {
            if(loginDto == null)
            {
                return BadRequest();
            }

            await _authService.Login(loginDto.Email, loginDto.Password);
            var user = await _userService.GetUser(loginDto.Email);
            var jwt = _jwtService.CreateToken(user.UserId, user.Role);

            return Ok(jwt);
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDTO registerDto)
        {
            if(registerDto == null)
            {
                return BadRequest();
            }

            try
            {
                _authService.Register(registerDto.Email, registerDto.Firstname, registerDto.Lastname, registerDto.Username, registerDto.Password, registerDto.Role);

                return Ok();    //Return RegisterReadDTO with created user? Or wait for mail verification?
            }
            catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
