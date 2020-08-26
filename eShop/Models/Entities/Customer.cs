using eShop.Models.ValueObjects;
using System;

namespace eShop.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }    //Other type with validation

        public Address Address { get;  set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
