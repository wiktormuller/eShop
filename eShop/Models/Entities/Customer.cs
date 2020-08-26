using eShop.Models.ValueObjects;
using System;

namespace eShop.Models.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }    //Other type with validation

        public Address Address { get; private set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
