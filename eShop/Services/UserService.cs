using eShop.Infrastructure;
using eShop.Domain.Entities;
using eShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class UserService : IUser
    {
        private readonly eShopDbContext _context;

        public UserService(eShopDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
