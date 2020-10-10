namespace eShop.Domain.Entities
{
    public class Jwt
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
