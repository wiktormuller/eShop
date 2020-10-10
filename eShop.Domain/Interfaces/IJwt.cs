using eShop.DTO;

namespace eShop.Domain.Interfaces
{
    public interface IJwt
    {
        JwtDTO CreateToken(int userId, string role);
    }
}
