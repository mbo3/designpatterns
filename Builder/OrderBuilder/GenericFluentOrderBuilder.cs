using Builder.Models;

namespace Builder.OrderBuilder
{
    class GenericFluentOrderBuilder<Self> where Self : GenericFluentOrderBuilder<Self>
    {
        protected Order order = new Order();

        public Self Number(int number)
        {
            order.Number = number;
            return (Self)this;
        }

        public Self For(Person client)
        {
            order.Client = client;
            return (Self)this;
        }

        public Self ShipTo(Address shippingAddress)
        {
            order.ShippingAddress = shippingAddress;
            return (Self)this;
        }

        public Self Billing(Address billingAddress)
        {
            order.BillingAddress = billingAddress;
            return (Self)this;
        }

        public Self AddProduct(Product product, int quanity)
        {
            order.Products.Add(new OrderProduct(product, quanity));
            return (Self)this;
        }

        public Self Clear()
        {
            order = new Order();
            return (Self)this;
        }

        public Order Build()
        {
            if (order.BillingAddress == null)
                order.BillingAddress = order.ShippingAddress;

            return order;
        }
    }
}
