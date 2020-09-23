using System;
using System.Text.RegularExpressions;

namespace eShop.Models.Entities
{
    public class User
    {
        private readonly Regex RegexOfUsername = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public int UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(int userId, string email, string username, string role, string password, string salt)
        {
            UserId = userId;
            SetEmail(email);
            SetUsername(username);
            SetRole(role);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if(!RegexOfUsername.IsMatch(username))
            {
                //throw new DomainException(ErrorCodes.InvalidUsername, "Username is inalid");
            }

            if(string.IsNullOrEmpty(username))
            {
                //throw new DomainException(ErrorCodes.InvalidUsername, "Username is invalid");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                //throw new DomainException(ErrorCodes.InvalidEmail, "Email cannot be empty");
            }

            if(Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if(string.IsNullOrWhiteSpace(role))
            {
                //throw new DomainException(ErrorCodes.InvalidRole, "Role cannot be empty");
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
                //throw new DomainException(ErrorCodes.InvalidPassword, "Password cannot be empty");
            }

            if(string.IsNullOrWhiteSpace(salt))
            {
                //throw new DomainException(ErrorCodes.InvalidPassword, "Salt cannot be empty");
            }

            if(password.Length < 4)
            {
                //throw new DomainException(ErrorCodes.InvalidPassword, "Password must contain at least 4 characters");
            }

            if(password.Length > 100)
            {
                //throw new DomainException(ErrorCodes.InvalidPassword, "Password cannot contain more than 100 characters");
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
