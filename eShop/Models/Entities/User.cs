﻿using eShop.Exceptions;
using eShop.Models.ValueObjects;
using System;
using System.Text.RegularExpressions;

namespace eShop.Models.Entities
{
    public class User
    {
        private readonly Regex RegexOfUsername = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public int UserId { get; protected set; }
        public string Email { get; protected set; } //Should it be other type with validation?
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Address Address { get; protected set; }
        public int? OrderId { get; protected set; }
        public Order Order { get; protected set; }

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
                throw new DomainException(DomainErrorCodes.InvalidUsername, "Username is inalid");
            }

            if(string.IsNullOrEmpty(username))
            {
                throw new DomainException(DomainErrorCodes.InvalidUsername, "Username is invalid");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new DomainException(DomainErrorCodes.InvalidEmail, "Email cannot be empty");
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
                throw new DomainException(DomainErrorCodes.InvalidLastname, "Lastname is invalid");
            }
            Lastname = lastName;
        }

        public void SetFirstname(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new DomainException(DomainErrorCodes.InvalidFirstname, "Firstname is invalid.");
            }
            Firstname = firstName;
        }

        public void SetRole(string role)
        {
            if(string.IsNullOrWhiteSpace(role))
            {
                throw new DomainException(DomainErrorCodes.InvalidRole, "Role cannot be empty");
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
                throw new DomainException(DomainErrorCodes.InvalidPassword, "Password cannot be empty");
            }

            if(string.IsNullOrWhiteSpace(salt))
            {
                throw new DomainException(DomainErrorCodes.InvalidPassword, "Salt cannot be empty");
            }

            if(password.Length < 4)
            {
                throw new DomainException(DomainErrorCodes.InvalidPassword, "Password must contain at least 4 characters");
            }

            if(password.Length > 100)
            {
                throw new DomainException(DomainErrorCodes.InvalidPassword, "Password cannot contain more than 100 characters");
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
