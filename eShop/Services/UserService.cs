using eShop.DTO;
using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Services
{
    public class UserService : IUser
    {
        private readonly eShopDbContext _context;
        private readonly IEncrypter _encrypter;

        public UserService(eShopDbContext context, IEncrypter encrypter)
        {
            _context = context;
            _encrypter = encrypter;
        }

        public UserDTO GetUser(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return new UserDTO
            {
                Id = user.UserId,
                Email = user.Email,
                Role = user.Role,
                Username = user.Username,
                FullName = user.FullName
            };
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var model = _context.Users;
            var users = model.Select(u =>
                new UserDTO
                {
                    Id = u.UserId,
                    Email = u.Email,
                    Role = u.Role,
                    Username = u.Username,
                    FullName = u.FullName
                }).ToList();

            return users;
        }

        public void Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if(user == null)
            {
                //throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            //throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
        }

        public void Register(int userId, string email, string username, string password, string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if(user != null)
            {
                //throw new ServiceException(ErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, role, hash, salt);
            _context.Add(user);
        }
    }
}
