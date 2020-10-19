namespace eShop.Domain.Entities
{
    public class Jwt
    {
        public string Token { get; private set; }
        public long Expires { get; private set; }

        public Jwt(string token, long expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
