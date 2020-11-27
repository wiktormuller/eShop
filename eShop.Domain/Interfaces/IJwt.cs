using eShop.Domain.Entities;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IJwt
    {
        Jwt CreateToken(int userId, string role);
    }
}
