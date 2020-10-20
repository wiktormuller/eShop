using System;

namespace eShop.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException();
            }
            Name = name;
        }
    }
}
