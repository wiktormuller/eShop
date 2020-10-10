using System;
using System.Threading.Tasks;
using eShop.DTO;
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDto)
        {
            loginDto.TokenId = Guid.NewGuid();

            await _authService.Login(loginDto.Email, loginDto.Password);
            var user = await _userService.GetUser(loginDto.Email);
            var jwt = _jwtService.CreateToken(user.UserId, user.Role);

            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO registerDto)
        {
            await _authService.Register(registerDto.UserId, registerDto.Email, registerDto.Firstname, registerDto.Lastname, registerDto.Username, registerDto.Password, registerDto.Role);
            var createdUser = _userService.GetUser(registerDto.Email);

            return Ok(createdUser);
        }
    }
}
