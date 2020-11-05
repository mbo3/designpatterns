using Builder.Models;
using Builder.OrderBuilder;
using System;

namespace DesignPatternsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            Product[] products = new Product[]
            {
                new Product("Helmet", 50.69f),
                new Product("Hammer", 15.30f),
                new Product("Nails", 5.00f)
            };

            var rng = new Random();

            // basic builder
            var orderBuilder = new OrderBuilder();
            orderBuilder.Number(100);
            orderBuilder.For(new Person("John", "Doe"));
            orderBuilder.ShipTo(new Address("Baker", 65, 28, "Los Angeles", "00-000"));
            foreach (var product in products)
                orderBuilder.AddProduct(product, rng.Next(1, 10));

            order = orderBuilder.Build();
            orderBuilder.Billing(new Address("Jefferson", 13, null, "New York", "11-111"));
            var order2 = orderBuilder.Build();
            Console.WriteLine(order);
            Console.WriteLine(order2);


            // fluent api builder
            var fluentBuilder = new FluentOrderBuilder();
            order = fluentBuilder
                            .Number(25)
                            .For(new Person("Jane", "Doe"))
                            .ShipTo(new Address("Baker", 65, 28, "Los Angeles", "00-000"))
                            .AddProduct(products[0], rng.Next(1, 10))
                            .AddProduct(products[1], rng.Next(1, 10))
                            .Build();

            Console.WriteLine(order) ;


            // inherited fluent builder
            var inheritedBuilder = Order.CreateBuilder();
            order = inheritedBuilder
                            .IsSpecial()
                            .Number(25)
                            .For(new Person("Jane", "Doe"))
                            .ShipTo(new Address("Baker", 65, 28, "Los Angeles", "00-000"))
                            .AddProduct(products[0], rng.Next(1, 10))
                            .AddProduct(products[1], rng.Next(1, 10))
                            .Build();

            Console.WriteLine(order);


            // functional builder
            var funcBuilder = new FunctionalOrderBuilder();
            order = funcBuilder
                        .Number(911)
                        .Do(o => o.SpecialOrder = true)
                        .Build();

            Console.WriteLine(order);
        }
    }
}
