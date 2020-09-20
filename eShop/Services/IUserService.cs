using eShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Services
{
    public interface IUserService
    {
        UserDTO GetUser(string email);
        IEnumerable<UserDTO> GetUsers();
        void Register(int userId, string email, string username, string password, string role);
        void Login(string email, string password);
    }
}
