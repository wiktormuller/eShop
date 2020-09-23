using eShop.DTO;

namespace eShop.Models.Interfaces
{
    public interface IJwt
    {
        JwtDTO CreateToken(int userId, string role);
    }
}
