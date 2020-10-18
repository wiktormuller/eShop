using eShop.Domain.Entities;

namespace eShop.Domain.ValueObjects
{
    public class Address
    {
        public int AddressId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public int UserId { get; set; }
        public User Customer { get; set; }
    }
}
