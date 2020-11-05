using Builder.Models;

namespace Builder.OrderBuilder
{
    sealed class FluentOrderBuilder
    {
        private Order order = new Order();

        public FluentOrderBuilder Number(int number)
        {
            order.Number = number;
            return this;
        }

        public FluentOrderBuilder For(Person client)
        {
            order.Client = client;
            return this;
        }

        public FluentOrderBuilder ShipTo(Address shippingAddress)
        {
            order.ShippingAddress = shippingAddress;
            return this;
        }

        public FluentOrderBuilder Billing(Address billingAddress)
        {
            order.BillingAddress = billingAddress;
            return this;
        }

        public FluentOrderBuilder AddProduct(Product product, int quanity)
        {
            order.Products.Add(new OrderProduct(product, quanity));
            return this;
        }

        public FluentOrderBuilder Clear()
        {
            order = new Order();
            return this;
        }

        public Order Build()
        {
            if (order.BillingAddress == null)
                order.BillingAddress = order.ShippingAddress;

            return order;
        }
    }
}
