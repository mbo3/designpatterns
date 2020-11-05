using System;

namespace Builder.Models
{
    class Product
    {
        public Product(string name, float price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public string Name { get; set; }
        public float Price { get; set; }
    }
}
