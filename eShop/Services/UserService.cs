using eShop.DTO;
using eShop.Exceptions;
using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<UserDTO> GetUser(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return new UserDTO
            {
                Id = user.UserId,
                Email = user.Email,
                Role = user.Role,
                Username = user.Username,
                FullName = user.FullName
            };
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var model = await _context.Users.ToListAsync();
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

        public async Task Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                throw new ServiceException(ServiceErrorCodes.InvalidCredentials, "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ServiceErrorCodes.InvalidCredentials, "Invalid credentials");
        }

        public async Task Register(int userId, string email, string username, string password, string role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user != null)
            {
                throw new ServiceException(ServiceErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, role, hash, salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
