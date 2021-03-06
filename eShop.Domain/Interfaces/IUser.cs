﻿using eShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IUser
    {
        Task<User> GetUser(string email);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task UpdateUser(User user);
    }
}
