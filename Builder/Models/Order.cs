using Builder.OrderBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder.Models
{
    class Order
    {
        public int Number { get; set; }
        public float Total => Products.Sum(x => x.Product.Price * x.Quanity);
        public Person Client { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public bool SpecialOrder { get; set; }

        public List<OrderProduct> Products { get; set; }

        public Order()
        {
            Products = new List<OrderProduct>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Order: {Number}");
            if (SpecialOrder)
                sb.AppendLine("This order is special");
            sb.AppendLine("Customer:");
            sb.AppendLine(Client?.ToString());
            sb.AppendLine("Shipping:");
            sb.Append(ShippingAddress?.ToString());
            sb.AppendLine("Billing address:");
            if (ShippingAddress == BillingAddress)
                sb.AppendLine("The same as shipping address");
            else
                sb.Append(BillingAddress?.ToString());

            sb.AppendLine("Products:");
            Products.ForEach(p => sb.AppendLine(p.ToString()));

            sb.AppendLine($"Total: {Total.ToString("$ 0.00")}");

            return sb.ToString();
        }

        public class Builder : InheritedFluentSpecialOrderBuilder<Builder>
        {
        }

        public static Builder CreateBuilder() => new Builder();

    }
}
