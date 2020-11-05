using System;
using System.Text;

namespace Builder.Models
{
    class Address
    {
        // Here are a lot of params in the ctor, we can also create builder for Address type
        public Address(string street, int houseNumber, int? flatNumber, string city, string postCode)
        {
            Street = street ?? throw new ArgumentNullException(nameof(street));
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            City = city ?? throw new ArgumentNullException(nameof(city));
            PostCode = postCode ?? throw new ArgumentNullException(nameof(postCode));
        }

        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var number = FlatNumber.HasValue ? $"{HouseNumber}/{FlatNumber.Value}" : HouseNumber.ToString();

            sb.AppendLine($"{Street} {number}");
            sb.AppendLine($"{PostCode}, {City}");

            return sb.ToString();
        }
    }
}
