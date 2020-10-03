using System;
using System.Threading.Tasks;
using eShop.DTO;
using eShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser _userService;
        private readonly IJwt _jwtService;

        public AuthController(IUser userService, IJwt jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDto)
        {
            loginDto.TokenId = Guid.NewGuid();

            await _userService.Login(loginDto.Email, loginDto.Password);
            var user = await _userService.GetUser(loginDto.Email);
            var jwt = _jwtService.CreateToken(user.Id, user.Role);

            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO registerDto)
        {
            await _userService.Register(registerDto.UserId, registerDto.Email, registerDto.Username, registerDto.Password, registerDto.Role);
            var createdUser = _userService.GetUser(registerDto.Email);

            return Ok(createdUser);
        }
    }
}
