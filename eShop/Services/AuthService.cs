using eShop.Exceptions;
using eShop.Infrastructure;
using eShop.Models.Entities;
using eShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class AuthService : IAuth
    {
        private readonly eShopDbContext _context;
        private readonly IEncrypter _encrypter;

        public AuthService(eShopDbContext context, IEncrypter encrypter)
        {
            _context = context;
            _encrypter = encrypter;
        }

        public async Task Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new ServiceException(ServiceErrorCodes.InvalidCredentials, "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ServiceErrorCodes.InvalidCredentials, "Invalid credentials");
        }

        public async Task Register(int userId, string email, string firstname, string lastname, string username, string password, string role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                throw new ServiceException(ServiceErrorCodes.EmailInUse, $"User with email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, firstname, lastname, username, role, hash, salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
