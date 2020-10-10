using System;

namespace eShop.Infrastructure.DTO
{
    public class LoginDTO
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
