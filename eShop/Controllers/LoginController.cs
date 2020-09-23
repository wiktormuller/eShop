using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.DTO;
using eShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDto)
        {
            loginDto.TokenId = Guid.NewGuid();

            _userService.Login(loginDto.Email, loginDto.Password);
            var user = _userService.GetUser(loginDto.Email);
            var jwt = _jwtService.CreateToken(user.Id, user.Role);

            return Ok(jwt);
        }
    }
}
