namespace eShop.Infrastructure.DTO
{
    public class UserCreateDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
