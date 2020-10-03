using eShop.Exceptions;
using eShop.Models.ValueObjects;
using System;

namespace eShop.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get;  protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }    //Other type with validation

        public Address Address { get; protected set; }

        public int? OrderId { get; protected set; }
        public Order Order { get; protected set; }

        public Customer(int customerId, string firstName, string lastName, string email)
        {
            CustomerId = customerId;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new DomainException(DomainErrorCodes.InvalidEmail, "Email is invalid");
            }
            if(Email == email)
            {
                return;
            }
            Email = email;
        }

        public void SetLastName(string lastName)
        {
            if(string.IsNullOrEmpty(lastName))
            {
                throw new DomainException(DomainErrorCodes.InvalidLastname, "Lastname is invalid");
            }
            LastName = lastName;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrEmpty(firstName))
            {
                throw new DomainException(DomainErrorCodes.InvalidFirstname, "Firstname is invalid.");
            }
            FirstName = firstName;
        }
    }
}
