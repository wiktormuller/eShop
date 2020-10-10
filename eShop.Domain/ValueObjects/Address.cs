using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public int UserId { get; set; }
        public User Customer { get; set; }
    }
}
