using eShop.Domain.Entities;

namespace eShop.Domain.Interfaces
{
    public interface IJwt
    {
        Jwt CreateToken(int userId, string role);
    }
}
