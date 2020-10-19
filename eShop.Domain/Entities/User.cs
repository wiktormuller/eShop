using eShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace eShop.Domain.Entities
{
    public class User
    {
        private readonly Regex RegexOfUsername = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public int UserId { get; private set; }
        public string Email { get; private set; } //Should it be other type with validation?
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Username { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        //Relations
        public Address Address { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }

        public User(int userId, string email, string firstname, string lastname, string username, string role, string password, string salt)
        {
            UserId = userId;
            SetEmail(email);
            SetFirstname(firstname);
            SetLastname(lastname);
            SetUsername(username);
            SetRole(role);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if(!RegexOfUsername.IsMatch(username))
            {
                throw new ArgumentException();
            }

            if(string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException();
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException();
            }

            if(Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastname(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException();
            }
            Lastname = lastName;
        }

        public void SetFirstname(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException();
            }
            Firstname = firstName;
        }

        public void SetRole(string role)
        {
            if(string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException();
            }

            if(Role == role)
            {
                return;
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException();
            }

            if(string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentNullException();
            }

            if(password.Length < 4)
            {
                throw new ArgumentException();
            }

            if(password.Length > 100)
            {
                throw new ArgumentException();
            }

            if(Password == password)
            {
                return;
            }

            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
