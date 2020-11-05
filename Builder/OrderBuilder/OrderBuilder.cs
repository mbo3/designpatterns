using Builder.Models;

namespace Builder.OrderBuilder
{
    class OrderBuilder
    {
        private Order order = new Order();

        public void Number(int number)
        {
            order.Number = number;
        }

        public void For(Person client)
        {
            order.Client = client;
        }

        public void ShipTo(Address shippingAddress)
        {
            order.ShippingAddress = shippingAddress;
        }

        public void Billing(Address billingAddress)
        {
            order.BillingAddress = billingAddress;
        }

        public void AddProduct(Product product, int quanity)
        {
            order.Products.Add(new OrderProduct(product, quanity));
        }

        public void Clear()
        {
            order = new Order();
        }

        public Order Build()
        {
            if (order.BillingAddress == null)
                order.BillingAddress = order.ShippingAddress;

            return order;
        }
    }
}
