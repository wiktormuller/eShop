using eShop.Infrastructure;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
                throw new ArgumentNullException();
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ArgumentException();
        }

        public async Task Register(int userId, string email, string firstname, string lastname, string username, string password, string role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                throw new InvalidOperationException();
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, firstname, lastname, username, role, hash, salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
