using eShop.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Models.Interfaces
{
    public interface IUser
    {
        Task<UserDTO> GetUser(string email);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task Register(int userId, string email, string username, string password, string role);
        Task Login(string email, string password);
    }
}
