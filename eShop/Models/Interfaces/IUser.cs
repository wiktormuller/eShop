using eShop.DTO;
using System.Collections.Generic;

namespace eShop.Models.Interfaces
{
    public interface IUser
    {
        UserDTO GetUser(string email);
        IEnumerable<UserDTO> GetUsers();
        void Register(int userId, string email, string username, string password, string role);
        void Login(string email, string password);
    }
}
