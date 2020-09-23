using eShop.DTO;

namespace eShop.Services
{
    public interface IJwtService
    {
        JwtDTO CreateToken(int userId, string role);
    }
}
